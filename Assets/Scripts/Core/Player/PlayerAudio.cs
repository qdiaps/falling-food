using UnityEngine;

namespace Core.Player
{
    [RequireComponent(typeof(AudioSource), typeof(PlayerCollider))]
    public class PlayerAudio : MonoBehaviour
    {
        [SerializeField] private AudioClip _pickupAudio;

        private AudioSource _audio;

        private void Start()
        {
            _audio = GetComponent<AudioSource>();
            GetComponent<PlayerCollider>()
                .OnPickupFood += Pickup;
        }

        private void Pickup() =>
            _audio.PlayOneShot(_pickupAudio, 0.5f);
    }
}