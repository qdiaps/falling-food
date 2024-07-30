using Core.LeaderboardSystem;

namespace Core.Score
{
    public class ScoreHandler
    {
        private readonly Leaderboard _leaderboard;

        private int _currentScore;
        
        public ScoreHandler(Leaderboard leaderboard) => 
            _leaderboard = leaderboard;

        public int AddScore() => 
            _currentScore += 10;

        public int GetScore() =>
            _currentScore;

        public void SaveScore() => 
            _leaderboard.AddScore(_currentScore);
    }
}