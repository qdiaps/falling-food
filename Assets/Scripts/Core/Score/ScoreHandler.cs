using Core.LeaderboardSystem;
using UnityEngine;

namespace Core.Score
{
    public class ScoreHandler
    {
        private readonly Leaderboard _leaderboard;

        private int _currentScore;
        
        public ScoreHandler(Leaderboard leaderboard) => 
            _leaderboard = leaderboard;

        public int AddScore()
        {
            _currentScore += 10;
            Debug.Log(_currentScore);
            return _currentScore;
        }

        public int GetScore()
        {
            Debug.Log(_currentScore);
            return _currentScore;
        }

        public void SaveScore() => 
            _leaderboard.AddScore(_currentScore);
    }
}