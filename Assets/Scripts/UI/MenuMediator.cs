using Infrastructure.Service.Input;
using Infrastructure.Setting;
using VContainer;

namespace UI
{
    public class MenuMediator : Mediator
    {
        private Settings _settings;

        [Inject]
        public void Construct(Settings settings)
        {
            _settings = settings;
        }

        public void SetFpsValue(bool value) => 
            _settings.Values.IsFps = value;

        public void SetInputType(int indexType) =>
            _settings.Values.InputType = (InputType)indexType;

        public void ResetSettings() =>
            _settings.SetDefaultSettings();

        public void SaveSettings() =>
            _settings.Save();
    }
}