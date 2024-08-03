using Infrastructure.Service.Storage;

namespace Infrastructure.Setting
{
    public class Settings
    {
        public SettingsData Values { get; private set; }
        
        private const string SettingsJson = "settings.json";

        private readonly SettingsConfig _defaultSettings;
        private readonly IStorageService _storageService;

        public Settings(SettingsConfig defaultSettings, IStorageService storageService)
        {
            _defaultSettings = defaultSettings;
            _storageService = storageService;
            CheckSavedSettings();
        }

        public void Save() => 
            _storageService.Save(SettingsJson, Values);

        public void SetDefaultSettings() => 
            Values = _defaultSettings.Settings;

        private void CheckSavedSettings()
        {
            Values = _storageService.Load<SettingsData>(SettingsJson);
            if (Values == null)
            {
                SetDefaultSettings();
                Save();                
            }
        }
    }
}