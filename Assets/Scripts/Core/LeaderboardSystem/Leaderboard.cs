using System;
using Infrastructure.Service.Storage;

namespace Core.LeaderboardSystem
{
    public class Leaderboard
    {
        private const string LeaderboardFileName = "leaderboard.json";
        private const int MaxLineLeaderboard = 5;
        
        private readonly IStorageService _storageService;
        
        public Leaderboard(IStorageService storageService) => 
            _storageService = storageService;

        public int[] GetLeaderboardScore() => 
            _storageService.Load<int[]>(LeaderboardFileName);

        public void SaveDefaultLeaderboard() =>
            _storageService.Save(LeaderboardFileName, new int[MaxLineLeaderboard]);

        public void AddScore(int score)
        {
            if (score < 0)
                throw new ArgumentOutOfRangeException("score");
            
            var leaderboard = GetLeaderboardScore();
            if (leaderboard[MaxLineLeaderboard - 1] < score)
            {
                leaderboard[MaxLineLeaderboard - 1] = score;
                Array.Sort(leaderboard);
                _storageService.Save(LeaderboardFileName, leaderboard);
            }
        }
    }
}