using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class Click : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private AudioSource _audio;

        public void OnPointerDown(PointerEventData eventData) => 
            _audio.Play();
    }
}