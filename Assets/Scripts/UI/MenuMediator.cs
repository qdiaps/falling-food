using Infrastructure.Service.Input;
using Infrastructure.Service.Leaderboard;
using Infrastructure.Setting;
using VContainer;

namespace UI
{
    public class MenuMediator : Mediator
    {
        private Settings _settings;
        private LeaderboardService _leaderboardService;

        [Inject]
        public void Construct(Settings settings, LeaderboardService leaderboardService)
        {
            _leaderboardService = leaderboardService;
            _settings = settings;
        }

        public void SetFpsValue(bool value) => 
            _settings.Values.IsFps = value;

        public void SetInputType(int indexType) =>
            _settings.Values.InputType = (InputType)indexType;

        public void ResetSettings() =>
            _settings.SetDefaultSettings();

        public void ResetLeaderboard() =>
            _leaderboardService.ResetValues();

        public void SaveSettings() =>
            _settings.Save();

        public LeaderboardData[] GetLeaderboardData() =>
            _leaderboardService.GetLeaderboardData();
    }
}