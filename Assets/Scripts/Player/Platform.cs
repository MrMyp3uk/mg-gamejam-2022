using UnityEngine;

namespace Player
{
    public class Platform : MonoBehaviour
    {
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
            var translate = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
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
