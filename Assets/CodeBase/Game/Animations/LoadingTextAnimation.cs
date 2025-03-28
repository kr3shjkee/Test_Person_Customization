using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace CodeBase.Game.Animations
{
    public class LoadingTextAnimation : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private string _repeatingSymbols;
        [SerializeField] private int _symbolsCount;
        [SerializeField] private TMP_Text _text;

        private UnityAction _callback;
        
        public void PlayAnimation(UnityAction callback = null)
        {
            _callback = callback;
            StartCoroutine(TextCoroutine());
        }

        public void StopAnimation()
        {
            _callback?.Invoke();
            StopCoroutine(TextCoroutine());
        }
        
        private void OnDisable()
        {
            StopAnimation();
        }

        private void OnDestroy()
        {
            StopAnimation();
        }

        private IEnumerator TextCoroutine()
        {
            int count = 0;
            while (true)
            {
                if (count >= _symbolsCount)
                {
                    _text.text = String.Empty;
                    count = 0;
                }
                else
                {
                    _text.text += _repeatingSymbols;
                    count++;
                }
                yield return new WaitForSeconds(_duration);
            }
        }
    }
}