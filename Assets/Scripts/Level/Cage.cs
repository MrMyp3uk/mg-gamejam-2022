using System.Collections;
using Level.Interactable;
using Unity.VisualScripting;
using UnityEngine;

namespace Level
{
    public class Cage : MonoBehaviour
    {
        private static readonly int OpenTrigger = Animator.StringToHash("Open");
        private Animator _animator;

        [SerializeField]
        private Transform _border;
        [SerializeField]
        private Transform _cageBottom;
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void StartGame()
        {
            _animator.SetTrigger(OpenTrigger);
            
            StartCoroutine(DisableBorder());
        }

        IEnumerator DisableBorder()
        {
            yield return new WaitForSeconds(1f);
            
            _border.gameObject.SetActive(false);

            var bottom = _cageBottom.AddComponent<DestructibleObject>();
            bottom.Init(5);

        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartGame();
            }
        }
    }
}
