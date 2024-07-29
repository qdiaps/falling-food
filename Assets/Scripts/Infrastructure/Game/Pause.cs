using Infrastructure.FiniteStateMachine;
using UI;

namespace Infrastructure.Game
{
    public class Pause : InitPause
    {
        private readonly Mediator _mediator;

        public Pause(FSM fsm, Mediator mediator) : base(fsm)
        {
            _mediator = mediator;
        }

        public override void Enter()
        {
            base.Enter();
            _mediator.ShowPauseMenu();
        }

        public override void Exit()
        {
            base.Exit();
            _mediator.HidePauseMenu();
        }
    }
}