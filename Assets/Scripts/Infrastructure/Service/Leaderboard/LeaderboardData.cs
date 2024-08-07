using System;

namespace Infrastructure.Service.Leaderboard
{
    [Serializable]
    public class LeaderboardData : IComparable<LeaderboardData>
    {
        public int Score;
        public string Date;
        public string Time;

        public int CompareTo(LeaderboardData other)
        {
            if (other == null)
                throw new ArgumentException("Некорректное значение параметра");
            return Score.CompareTo(other.Score);
        }
    }
}