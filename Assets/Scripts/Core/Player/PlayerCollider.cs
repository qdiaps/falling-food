using System;
using UI;
using UnityEngine;
using VContainer;

namespace Core.Player
{
    public class PlayerCollider : MonoBehaviour
    {
        public event Action OnPickupFood;
        
        private Mediator _mediator;

        [Inject]
        public void Construct(Mediator mediator)
        {
            _mediator = mediator;
            OnPickupFood += _mediator.UpdateScore;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Markers.Food food))
            {
                Destroy(other.gameObject);
                OnPickupFood?.Invoke();
            }
        }
    }
}