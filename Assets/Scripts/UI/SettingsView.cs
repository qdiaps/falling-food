using Infrastructure.Service.Input;
using Infrastructure.Setting;
using UnityEngine;
using VContainer;

namespace UI
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField] private GameObject _fpsOn;
        [SerializeField] private GameObject _fpsOff;
        [SerializeField] private GameObject _inputAccelecation;
        [SerializeField] private GameObject _inputButton;

        private SettingsData _settings;

        [Inject]
        public void Consctruct(Settings settings) => 
            _settings = settings.Values;

        private void OnEnable()
        {
            SetActive(_settings.IsFps ? _fpsOn : _fpsOff);
            switch (_settings.InputType)
            {
                case InputType.MobileButton:
                    SetActive(_inputButton);
                    break;
                case InputType.MobileAcceleration:
                    SetActive(_inputAccelecation);
                    break;
            }
        }

        private void SetActive(GameObject obj) =>
            obj.SetActive(true);
    }
}