using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Level
{
    public class Spawner : MonoBehaviour
    {
        private static Spawner Instance;
        public static Vector2 GetSpawnPosition()
        {
            var x = Instance.transform.position.x + Random.Range(-Instance._width, Instance._width);
            var y = Instance.transform.position.y;
            
            return new Vector2(x, y);
        }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }

        [SerializeField]
        private float _width;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(transform.position, new Vector2(_width, 1));
        }
    }
}
