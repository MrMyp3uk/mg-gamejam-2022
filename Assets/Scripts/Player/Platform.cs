using UnityEngine;

namespace Player
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private float _mouseSpeed;
        [SerializeField] private float _keyboardSpeed;

        [SerializeField] private bool _mouseControl;

        private Rigidbody2D _rb;
        private Camera _camera;

        private float _leftSide = -11;
        private float _rightSide = 92;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _camera = Camera.main;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            var newPosition = transform.position;
            
            if (_mouseControl)
            {
                var mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
                var translate = (mousePos.x - transform.position.x) * Time.deltaTime * _mouseSpeed;
                newPosition = transform.position + new Vector3(translate, 0, 0);
            }
            else
            {
                var translate = Input.GetAxis("Horizontal") * _keyboardSpeed * Time.deltaTime;
                newPosition = transform.position + new Vector3(translate, 0, 0);
            }


            newPosition.x = Mathf.Clamp(newPosition.x, _leftSide, _rightSide);
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