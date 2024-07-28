using UnityEngine;

namespace Core.Player
{
    public class PlayerCollider : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Markers.Food food))
                Destroy(other.gameObject);
        }
    }
}