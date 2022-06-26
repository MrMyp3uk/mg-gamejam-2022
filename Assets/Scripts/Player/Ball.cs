using System.Collections;
using Level;
using Level.Interactable;
using Level.Interactable.Buffs;
using Unity.VisualScripting;
using UnityEngine;

namespace Player
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] private Transform _platform;

        [SerializeField] private float _maxSpeed;

        [SerializeField] private float _impulseForce;

        private Rigidbody2D _rb;
        private SpriteRenderer _render;

        private Vector2 _checkPoint = Vector2.zero;

        private PlayerStats _stats = new PlayerStats();
        public PlayerStats Stats => _stats;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _render = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            var magnitude = _rb.velocity.magnitude;

            if (magnitude > _maxSpeed)
            {
                _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _maxSpeed - 1);
            }

            _rb.angularVelocity = magnitude * 13;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            Collision(col.collider);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Collision(col);
        }

        private void Collision(Collider2D col)
        {
            if (col.transform.TryGetComponent<Platform>(out var platform))
            {
                _checkPoint = new Vector2(platform.transform.position.x, 2);
                _stats.Jump();
                return;
            }

            if (col.transform.TryGetComponent<NpcPlatform>(out var npcPlatform))
            {
                _checkPoint = new Vector2(npcPlatform.transform.position.x, 2);
                _stats.Jump();
                return;
            }

            if (col.transform.TryGetComponent<Ball>(out var ball))
            {
                _stats.CollisionOtherBall();
                return;
            }

            _stats.CollisionLevelItem();

            // Debug.Log(name + ": \n"+ _stats.ToString());
        }

        public void Reset()
        {
            var spawnPos = Spawner.GetSpawnPosition();

            var pos = spawnPos.x > _checkPoint.x ? spawnPos : _checkPoint;

            _rb.velocity = Vector2.zero;

            transform.position = pos;
            var platform = _platform.position;
            platform.x = pos.x;
            _platform.position = platform;

            _stats.Death();

            StartCoroutine(ResetWaiting());
        }

        private IEnumerator ResetWaiting()
        {
            _rb.simulated = false;
            _render.color = new Color(1, 1, 1, 0.5f);

            yield return new WaitForSeconds(0.1f);

            _render.color = new Color(1, 1, 1, 1f);
            
            yield return new WaitForSeconds(0.1f);
            
            _render.color = new Color(1, 1, 1, 0.5f);

            yield return new WaitForSeconds(0.1f);
            
            _render.color = new Color(1, 1, 1, 1f);
            
            yield return new WaitForSeconds(0.1f);
            
            _render.color = new Color(1, 1, 1, 0.5f);

            yield return new WaitForSeconds(0.1f);

            _render.color = new Color(1, 1, 1, 1);
            _rb.simulated = true;
        }

        public void Impulse()
        {
            _rb.AddForce(_rb.velocity.normalized * _impulseForce, ForceMode2D.Impulse);
        }

        public void Impulse(float scale)
        {
            var force = _impulseForce * scale;
            _rb.AddForce(_rb.velocity.normalized * force, ForceMode2D.Impulse);
        }

        public void Buff(BuffTarget target, float value, float time)
        {
            switch (target)
            {
                case BuffTarget.BallSize:
                    Resize(value, time);
                    break;
                case BuffTarget.PlatformSize:
                    ResizePlatform(value, time);
                    break;
                default:
                    return;
            }
        }

        public void Finish()
        {
            _platform.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        private void Resize(float value, float time)
        {
            if (transform.TryGetComponent<ResizerBuff>(out var resizer))
            {
                resizer.UpdateBuff(value, time);
                return;
            }

            var newResizer = transform.AddComponent<ResizerBuff>();
            newResizer.Init(value, time);
        }

        private void ResizePlatform(float value, float time)
        {
            if (_platform.TryGetComponent<ResizerBuff>(out var resizer))
            {
                resizer.UpdateBuff(value, time);
                return;
            }

            var newResizer = _platform.AddComponent<ResizerBuff>();
            newResizer.Init(value, time);
        }
    }
}