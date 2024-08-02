using System;
using UnityEngine;

namespace Core.Player
{
    public class PlayerCollider : MonoBehaviour
    {
        public event Action OnPickupFood;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Markers.Food food))
                OnPickupFood?.Invoke();
        }
    }
}