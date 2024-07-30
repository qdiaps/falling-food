using UnityEngine;

namespace Core.Player
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayerAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip _pickupAudio;
        [SerializeField] private PlayerCollider _playerCollider;

        private AudioSource _audio;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            _playerCollider.OnPickupFood += Pickup;
        }

        private void Pickup() =>
            _audio.PlayOneShot(_pickupAudio, 0.5f);
    }
}