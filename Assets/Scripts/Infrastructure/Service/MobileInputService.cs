using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Infrastructure.Service
{
    public class MobileInputService : MonoBehaviour, IInputService
    {
        public event Action<float> OnMove;

        public void Start() => 
            InputSystem.EnableDevice(Accelerometer.current);

        public void OnDestroy() => 
            InputSystem.DisableDevice(Accelerometer.current);

        public void Update()
        {
            var input = Accelerometer.current.acceleration.ReadValue();
            OnMove?.Invoke(input.x);
        }
    }
}