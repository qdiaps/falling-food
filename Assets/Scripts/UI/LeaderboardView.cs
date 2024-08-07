using TMPro;
using UnityEngine;
using VContainer;

namespace UI
{
    public class LeaderboardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _leaderboardView;
        
        private MenuMediator _mediator;

        [Inject]
        public void Construct(MenuMediator mediator) => 
            _mediator = mediator;

        private void OnEnable() => 
            UpdateLeaderboard();

        private void UpdateLeaderboard()
        {
            var data = _mediator.GetLeaderboardData();
            _leaderboardView.text = "";
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i].Score == 0)
                {
                    if (i == 0)
                        _leaderboardView.text = "У вас пока что нету рекордов.";
                    break;
                }

                var temp = data[i];
                _leaderboardView.text += $"{i + 1}. {temp.Date}   {temp.Time}\n    <b>{temp.Score}</b>\n";
            }
        }
    }
}