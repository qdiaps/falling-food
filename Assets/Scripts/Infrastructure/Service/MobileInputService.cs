using System;
using UnityEngine.InputSystem;
using VContainer.Unity;

namespace Infrastructure.Service
{
    public class MobileInputService : IInputService, IStartable, IDisposable, ITickable
    {
        public event Action<float> OnMove;

        public void Start() => 
            InputSystem.EnableDevice(Accelerometer.current);

        public void Dispose() => 
            InputSystem.DisableDevice(Accelerometer.current);

        public void Tick()
        {
            var input = Accelerometer.current.acceleration.ReadValue();
            OnMove?.Invoke(input.x);
        }
    }
}