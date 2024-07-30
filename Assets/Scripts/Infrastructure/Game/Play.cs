using Infrastructure.FiniteStateMachine;
using UI;

namespace Infrastructure.Game
{
    public class Play : State
    {
        private readonly Mediator _mediator;
        public Play(FSM fsm, Mediator mediator) : base(fsm)
        {
            _mediator = mediator;
        }

        public override void Enter()
        {
            if (_fsm.PastState.GetType() == typeof(GameOver))
                _mediator.Restart();
        }
    }
}