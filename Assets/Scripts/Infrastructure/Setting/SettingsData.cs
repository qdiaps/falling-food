using System;
using Infrastructure.Service.Input;

namespace Infrastructure.Setting
{
    [Serializable]
    public class SettingsData
    {
        public bool IsFps;
        public InputType InputType;
    }
}