using Player;
using UnityEngine;

namespace Level
{
    public class FinishWall : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.TryGetComponent<Ball>(out var ball))
            {
                ball.Finish();
                // TODO: Check if actually player reached the finish

                if (ball.IsPlayer)
                {
                    GameLifecycle.GameMode.Finish(true);
                }
            }
        }
    }
}