using Player;
using UnityEngine;

namespace Level.Interactable
{
    public class DestructibleObject : MonoBehaviour
    {
        [SerializeField] private int _counterAllHits;

        [Space] [SerializeField] private Sprite _brokenSprite;
        [SerializeField] private int _counterHitsToBroken;

        [Space] [SerializeField] private Transform _afterDestructionObject;
        [SerializeField] private float _timelifeAfterObject = 3f;

        private SpriteRenderer _renderer;
        private bool _isBroken;
        private int _hits;

        public void Init(int countHits)
        {
            _counterAllHits = countHits;
        }

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.TryGetComponent<Ball>(out var ball))
            {
                Hit();
            }
        }

        private void Hit()
        {
            _hits++;

            if (_hits >= _counterAllHits)
            {
                Destruct();
            }

            if (_isBroken == false && _hits >= _counterHitsToBroken)
            {
                Break();
            }
        }

        private void Break()
        {
            if (_brokenSprite != null)
            {
                _renderer.sprite = _brokenSprite;
            }

            _isBroken = true;
        }

        private void Destruct()
        {
            gameObject.SetActive(false);
            
            if (_afterDestructionObject != null)
            {
                var afterObject = Instantiate(_afterDestructionObject, transform.position, Quaternion.identity);
                Destroy(afterObject.gameObject, _timelifeAfterObject);
            }
        }
    }
}