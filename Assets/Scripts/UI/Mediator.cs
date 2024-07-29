using Infrastructure.FiniteStateMachine;
using Infrastructure.Game;
using UnityEngine;
using VContainer;

namespace UI
{
    public class Mediator : MonoBehaviour
    {
        private FSM _fsm;

        [Inject]
        public void Construct(FSM fsm)
        {
            _fsm = fsm;
        }
        
        public void ShowPauseMenu() =>
            Debug.Log("ShowPauseMenu");
        
        public void ShowGameOverMenu() =>
            Debug.Log("ShowGameOverMenu");

        public void HidePauseMenu() =>
            Debug.Log("HidePauseMenu");
        
        public void HideGameOverMenu() =>
            Debug.Log("HideGameOverMenu");

        public void SetPause() =>
            _fsm.SetState<Pause>();
        
        public void SetPlayMode() =>
            _fsm.SetState<Play>();
    }
}