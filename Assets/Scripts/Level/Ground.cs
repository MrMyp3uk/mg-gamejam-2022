using Player;
using UnityEngine;

namespace Level
{
    public class Ground : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent<Ball>(out var ball))
            {
                ball.Reset();
            }
        }
    }
}
