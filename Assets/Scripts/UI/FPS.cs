using System.Collections;
using Infrastructure.Setting;
using TMPro;
using UnityEngine;
using VContainer;

namespace UI
{
    public class FPS : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _updateSpeed = 1f;

        private int _currentFps;
        private Settings _settings;

        [Inject]
        public void Construct(Settings settings) => 
            _settings = settings;

        private void OnEnable()
        {
            if (_settings.Values.IsFps == false)
                gameObject.SetActive(false);
            else
                StartCoroutine(UpdateFPS());
        }

        private void Update() => 
            _currentFps = (int)(1f / Time.unscaledDeltaTime);

        private IEnumerator UpdateFPS()
        {
            while (true)
            {
                _text.text = $"{_currentFps}";
                yield return new WaitForSeconds(_updateSpeed);
            }
        }
    }
}