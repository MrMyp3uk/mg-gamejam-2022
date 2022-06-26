using System;
using Level;
using UnityEngine;

namespace Player
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private Transform _platform;
    
        [SerializeField]
        private float _maxSpeed;

        [SerializeField]
        private float _impulseForce;
    
        private Rigidbody2D _rb;

        private Vector2 _checkPoint = Vector2.zero;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            var magnitude = _rb.velocity.magnitude;

            if (magnitude > _maxSpeed)
            {
                _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _maxSpeed-1);
            }
            
            _rb.angularVelocity = magnitude * 13;
        }

        public void Reset()
        {
            // var pos = _checkPoint;
            var spawnPos = Spawner.GetSpawnPosition();
            // if (_checkPoint == Vector2.zero)
            // {
            // }

            var pos = spawnPos.x > _checkPoint.x ? spawnPos : _checkPoint;

            _rb.velocity = Vector2.zero;

            transform.position = pos;
            var platform = _platform.position;
            platform.x = pos.x;
            _platform.position = platform;
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

        public void Finish()
        {
            _platform.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.TryGetComponent<Platform>(out var platform))
            {
                _checkPoint = new Vector2(platform.transform.position.x, 5);
            }
            
            if (col.transform.TryGetComponent<NpcPlatform>(out var npcPlatform))
            {
                _checkPoint = new Vector2(npcPlatform.transform.position.x, 5);
            }
        }
    }
}
