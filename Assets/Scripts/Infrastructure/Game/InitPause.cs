using Infrastructure.FiniteStateMachine;
using UnityEngine;

namespace Infrastructure.Game
{
    public class InitPause : State
    {
        public InitPause(FSM fsm) : base(fsm) { }

        public override void Enter() => 
            Time.timeScale = 0f;

        public override void Exit() => 
            Time.timeScale = 1f;
    }
}