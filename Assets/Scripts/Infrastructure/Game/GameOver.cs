using Infrastructure.FiniteStateMachine;
using UI;

namespace Infrastructure.Game
{
    public class GameOver : InitPause
    {
        private readonly Mediator _mediator;

        public GameOver(FSM fsm, Mediator mediator) : base(fsm)
        {
            _mediator = mediator;
        }

        public override void Enter()
        {
            base.Enter();
            _mediator.ShowGameOverMenu();
        }

        public override void Exit()
        {
            base.Exit();
            _mediator.HideGameOverMenu();
        }
    }
}