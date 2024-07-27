using UnityEngine;
using UnityEngine.InputSystem;

namespace Core.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _force;
        
        private Rigidbody2D _rigidbody;
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            InputSystem.EnableDevice(Accelerometer.current);
        }

        private void OnDestroy() =>
            InputSystem.DisableDevice(Accelerometer.current);
        
        private void Update()
        {
            Vector3 accelerotion = Accelerometer.current.acceleration.ReadValue();
            _rigidbody.velocity = new Vector2(accelerotion.x * _force, 0f);
        }
    }
}
