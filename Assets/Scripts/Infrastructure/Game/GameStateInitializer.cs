using Infrastructure.FiniteStateMachine;
using UI;
using VContainer.Unity;

namespace Infrastructure.Game
{
    public class GameStateInitializer : IInitializable
    {
        private readonly FSM _fsm;
        private readonly Mediator _mediator;

        public GameStateInitializer(FSM fsm, Mediator mediator)
        {
            _fsm = fsm;
            _mediator = mediator;
        }

        public void Initialize()
        {
            _fsm.AddState(new InitPause(_fsm));
            _fsm.AddState(new Pause(_fsm, _mediator));
            _fsm.AddState(new Play(_fsm, _mediator));
            _fsm.AddState(new GameOver(_fsm, _mediator));

            _fsm.SetState<InitPause>();
        }
    }
}