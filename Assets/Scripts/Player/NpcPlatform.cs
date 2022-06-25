using UnityEngine;

namespace Player
{
    public class NpcPlatform : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private float _speed;

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var translate = _ball.transform.position.x - transform.position.x;
            var newPosition = transform.position + new Vector3(translate, 0, 0);        
        
            _rb.MovePosition(newPosition);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.TryGetComponent<Ball>(out var ball))
            {
                ball.Impulse();
            }
        }
    }
}
