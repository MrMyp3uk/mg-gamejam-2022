using System;
using Player;
using UnityEngine;

namespace Level.Interactable
{
    public class AdditionalImpulse : MonoBehaviour
    {
        [SerializeField]
        private float _impulseScale;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.TryGetComponent<Ball>(out var ball))
            {
                ball.Impulse(_impulseScale);
            }
        }
    }
}
