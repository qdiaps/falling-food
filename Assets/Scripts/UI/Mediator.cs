using Infrastructure.FiniteStateMachine;
using Infrastructure.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace UI
{
    public class Mediator : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _gameOverMenu;
        
        private FSM _fsm;

        [Inject]
        public void Construct(FSM fsm)
        {
            _fsm = fsm;
        }

        public void ShowPauseMenu() =>
            _pauseMenu.SetActive(true);

        public void ShowGameOverMenu() =>
            _gameOverMenu.SetActive(true);

        public void HidePauseMenu() =>
            _pauseMenu.SetActive(false);

        public void HideGameOverMenu() =>
            _gameOverMenu.SetActive(false);

        public void SetPause() =>
            _fsm.SetState<Pause>();
        
        public void SetPlayMode() =>
            _fsm.SetState<Play>();

        public int GetScore() => 
            100;

        public void Restart() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        public void Exit() =>
            Application.Quit();
    }
}