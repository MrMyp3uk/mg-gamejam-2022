using Player;
using UnityEngine;

namespace Level.Interactable
{
    public class DestructibleObject : MonoBehaviour
    {
        [SerializeField]
        private int _counterHits;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.transform.TryGetComponent<Ball>(out var ball))
            {
                DecreaseCounter();
            }
        }

        private void DecreaseCounter()
        {
            _counterHits--;

            if (_counterHits > 0)
            {
                return;
            }
            
            gameObject.SetActive(false);
        }
    }
}
