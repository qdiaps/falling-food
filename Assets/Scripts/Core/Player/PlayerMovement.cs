using Infrastructure.Service.Input;
using UnityEngine;
using VContainer;

namespace Core.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private IInputService _inputService;
        private Rigidbody2D _rigidbody;

        [Inject]
        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _inputService.OnMove += Move;
        }

        private void OnDestroy() => 
            _inputService.OnMove -= Move;

        private void Move(float direction) => 
            _rigidbody.velocity = new Vector2(direction * 7, _rigidbody.velocity.y);
    }
}