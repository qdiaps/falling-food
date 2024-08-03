using UnityEngine;

namespace Infrastructure.Setting
{
    [CreateAssetMenu(fileName="NewSettingsConfig", menuName="Configs/Settings")]
    public class SettingsConfig : ScriptableObject
    {
        public SettingsData Settings;
    }
}