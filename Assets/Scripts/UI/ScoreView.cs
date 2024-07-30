using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private Mediator _mediator;
        // [SerializeField] private int _fontSizeNewRecord = 75;
        [SerializeField] private int _fontSizeDefault = 90;
        
        private void OnEnable()
        {
            var score = _mediator.GetLastScore();
            UpdateScore(score);
        }

        private void UpdateScore(int score)
        {
            _scoreText.fontSize = _fontSizeDefault;
            _scoreText.text = $"Счёт: {score}";
        }
    }
}