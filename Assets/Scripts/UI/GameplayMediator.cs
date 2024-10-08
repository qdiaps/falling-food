﻿using Core.Score;
using Infrastructure.FiniteStateMachine;
using Infrastructure.Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;

namespace UI
{
    public class GameplayMediator : Mediator
    {
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private GameObject _pauseMenu;
        [SerializeField] private GameObject _gameOverMenu;
        
        private FSM _fsm;
        private ScoreHandler _scoreHandler;

        [Inject]
        public void Construct(FSM fsm, ScoreHandler scoreHandler)
        {
            _fsm = fsm;
            _scoreHandler = scoreHandler;
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

        public void UpdateScore() => 
            _scoreView.UpdateScore(_scoreHandler.AddScore());

        public void UpdateScoreResult() =>
            _scoreView.UpdateResultScore(_scoreHandler.GetScore());

        public void SaveScore() =>
            _scoreHandler.SaveScore();

        public void Restart() =>
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}