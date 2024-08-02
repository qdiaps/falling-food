using TMPro;
using UnityEngine;
using VContainer;

namespace UI
{
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _leaderboardView;
        
        private GameplayMediator _gameplayMediator;

        [Inject]
        public void Construct(GameplayMediator gameplayMediator) => 
            _gameplayMediator = gameplayMediator;

        private void OnEnable() => 
            UpdateLeaderboard();

        private void UpdateLeaderboard()
        {
            var leaderboard = _gameplayMediator.GetLeaderboardScore();
            _leaderboardView.text = "";
            for (int i = 0; i < leaderboard.Length; i++)
            {
                if (leaderboard[i] == 0 && i != 0)
                    break;
                _leaderboardView.text += $"{i + 1}. {leaderboard[i]}\n";
            }
        }
    }
}