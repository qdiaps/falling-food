using System;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Infrastructure.Service
{
    public class EditorInputService : IInputService, IStartable, ITickable, IDisposable
    {
        public event Action<float> OnMove;
        
        public void Start() => 
            InputSystem.EnableDevice(Keyboard.current);

        public void Dispose() => 
            InputSystem.DisableDevice(Keyboard.current);

        public void Tick()
        {
            if (Keyboard.current.aKey.isPressed)
                OnMove?.Invoke(-1f);
            else if (Keyboard.current.dKey.isPressed)
                OnMove?.Invoke(1f);
        }
    }
}