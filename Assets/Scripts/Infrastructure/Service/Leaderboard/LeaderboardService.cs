using System;
using Infrastructure.Service.Storage;
using Newtonsoft.Json;

namespace Infrastructure.Service.Leaderboard
{
    public class LeaderboardService
    {
        private const string LeaderboardFileName = "leaderboard.json";

        private readonly IStorageService _storageService;

        private LeaderboardData[] _data;

        public LeaderboardService(IStorageService storageService)
        {
            _storageService = storageService;
            ValidateLeaderboardData();
        }

        public void ResetValues()
        {
            _data = new []
            {
                new LeaderboardData(),
                new LeaderboardData(),
                new LeaderboardData(),
                new LeaderboardData(), 
                new LeaderboardData()
            };
            Save();
        }

        public LeaderboardData[] GetLeaderboardData() => 
            _data;

        public void AddScore(int score)
        {
            if (score < 0)
                throw new ArgumentOutOfRangeException("score");

            var leaderboard = _data[^1];
            if (leaderboard.Score < score)
            {
                leaderboard.Score = score;
                var dateTime = DateTime.Now;
                leaderboard.Date = $"{DateTimeToString(new []{dateTime.Day, dateTime.Month, dateTime.Year}, '.')}";
                leaderboard.Time = $"{DateTimeToString(new []{dateTime.Hour, dateTime.Minute, dateTime.Second}, ':')}";
                Array.Sort(_data);
                Array.Reverse(_data);
                Save();
            }
        }

        private string DateTimeToString(int[] values, char separator)
        {
            string result = "";

            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                result += value < 10 ? $"0{value}" : value;
                if (i != values.Length - 1)
                    result += separator;
            }
            
            return result;
        }

        private void ValidateLeaderboardData()
        {
            try
            {
                _data = _storageService.Load<LeaderboardData[]>(LeaderboardFileName);
            }
            catch (JsonSerializationException)
            {
                ResetValues();
                return;
            }

            if (_data == null)
                ResetValues();
        }
        
        private void Save() =>
            _storageService.Save(LeaderboardFileName, _data);
    }
}