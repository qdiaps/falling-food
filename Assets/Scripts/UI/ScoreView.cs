using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _score;
        [SerializeField] private TMP_Text _scoreResult;
        
        public void UpdateScore(int score) => 
            _score.text = $"{score}";

        public void UpdateResultScore(int score) => 
            _scoreResult.text = $"Счёт: {score}";
    }
}