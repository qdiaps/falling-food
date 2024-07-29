using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class FPS : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _updateSpeed = 1f;

        private int _currentFps;

        private void Start() => 
            StartCoroutine(UpdateFPS());

        private IEnumerator UpdateFPS()
        {
            while (true)
            {
                _text.text = $"{_currentFps}";
                yield return new WaitForSeconds(_updateSpeed);
            }
        }

        private void Update() => 
            _currentFps = (int)(1f / Time.unscaledDeltaTime);
    }
}