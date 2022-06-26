using System;
using Player;
using UnityEngine;

namespace Level.Interactable
{
    public class Buff : MonoBehaviour
    {
        [SerializeField] private BuffTarget _target;

        [SerializeField] private float _value;
        [SerializeField] private float _time;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.transform.TryGetComponent<Ball>(out var ball))
            {
                ball.Buff(_target, _value, _time);
                gameObject.SetActive(false);
            }
        }
    }

    public enum BuffTarget
    {
        BallSize,
        PlatformSize
    }
}