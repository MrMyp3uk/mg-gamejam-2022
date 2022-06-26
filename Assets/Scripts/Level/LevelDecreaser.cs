using System;
using Player;
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
        
        [SerializeField]
        private Transform _border;

        [SerializeField] private Platform _platform;


        private void Awake()
        {
            // _collider = GetComponent<PolygonCollider2D>();
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
            _border.position = new Vector2(_border.position.x + translate, 0);

            _platform.DecreaseLeftSide(translate);
        }
    }
}
