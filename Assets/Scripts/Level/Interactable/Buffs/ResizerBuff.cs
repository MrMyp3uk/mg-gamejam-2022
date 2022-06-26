using System;
using UnityEngine;

namespace Level.Interactable.Buffs
{
    public class ResizerBuff : MonoBehaviour
    {
        private float _value;
        private float _time;

        private float _timer;

        public void Init(float value, float time)
        {
            _value = value;
            _time = time;
        }

        public void UpdateBuff(float value, float time)
        {
            if (Math.Abs(value - _value) < 0.1f)
            {
                _time += time;
            }
            else
            {
                EndBuff();
            }
        }
        
        private void Start()
        {
            transform.localScale = Vector3.one * _value;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _time)
            {
                EndBuff();
            }
        }

        private void EndBuff()
        {
            transform.localScale = Vector3.one;
            Destroy(this);
        }

        // private void OnStartBuff()
        // {
        //     
        // }
        //
        // private void OnEndBuff()
        // {
        //     
        // }
        //
        // private void OnUpdate()
        // {
        //     
        // }
    }
}