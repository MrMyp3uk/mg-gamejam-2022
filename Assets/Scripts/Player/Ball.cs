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

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var magnitude = _rb.velocity.magnitude;

            if (magnitude > _maxSpeed)
            {
                _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, _maxSpeed);
            }
            
            _rb.angularVelocity = magnitude * 13;
        }

        public void Reset()
        {
            _rb.velocity = Vector2.zero;

            transform.position = new Vector3(_platform.position.x, 3, 0);
        }

        public void Impulse()
        {
            _rb.AddForce(_rb.velocity.normalized * _impulseForce, ForceMode2D.Impulse);
        }

        public void Finish()
        {
            _platform.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
