using System;
using UnityEngine;

namespace Level
{
    public class LevelDecreaser : MonoBehaviour
    {
        [SerializeField]
        private Transform _backWall;

        [Space]
        [SerializeField]
        private float _decreaseDelay;
        [SerializeField]
        private float _decreaseSpeed;
        
        private PolygonCollider2D _collider;


        private void Awake()
        {
            _collider = GetComponent<PolygonCollider2D>();
        }

        private void Update()
        {
            if (_decreaseDelay > 0)
            {
                DecreaseDelay();
            }
            else
            {
                DecreaseLevel();
            }
            
            
        }

        private void DecreaseDelay()
        {
            _decreaseDelay -= Time.deltaTime;
        }

        private void DecreaseLevel()
        {
            var translate = Time.deltaTime * _decreaseSpeed;
            _backWall.position += new Vector3(translate, 0, 0);
            _collider.offset = new Vector2(_collider.offset.x + translate, 0);

        }
    }
}
