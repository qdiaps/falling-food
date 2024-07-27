using Core.Foods;
using TMPro;
using UnityEngine;

namespace Core.Player
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreUI;

        private int _currentScore;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Food food))
            {
                UpdateScore();
                Destroy(other.gameObject);             
            }
        }

        private void UpdateScore()
        {
            _currentScore++;
            _scoreUI.text = $"{_currentScore}";
        }
    }
}