using System;
using Core.Markers;
using Core.Player;
using Infrastructure.FiniteStateMachine;
using Infrastructure.Game;
using UI;
using UnityEngine;
using VContainer;

namespace Core.Food
{
    public class FoodCollider : MonoBehaviour
    {
        public event Action OnPickupFood;
        
        private FSM _gameStateHandler;
        private GameplayMediator _gameplayMediator;

        [Inject]
        public void Construct(FSM gameStateHandler, GameplayMediator gameplayMediator)
        {
            _gameplayMediator = gameplayMediator;
            OnPickupFood += _gameplayMediator.UpdateScore;
            _gameStateHandler = gameStateHandler;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Background background))
                _gameStateHandler.SetState<GameOver>();
            else if (other.TryGetComponent(out PlayerMovement player))
            {
                OnPickupFood?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}