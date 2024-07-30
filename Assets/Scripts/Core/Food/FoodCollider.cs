using Core.Markers;
using Infrastructure.FiniteStateMachine;
using Infrastructure.Game;
using UnityEngine;
using VContainer;

namespace Core.Food
{
    public class FoodCollider : MonoBehaviour
    {
        private FSM _gameStateHandler;

        [Inject]
        public void Construct(FSM gameStateHandler) => 
            _gameStateHandler = gameStateHandler;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Background background))
                _gameStateHandler.SetState<GameOver>();
        }
    }
}