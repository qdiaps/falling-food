using Infrastructure.FiniteStateMachine;
using UI;
using VContainer.Unity;

namespace Infrastructure.Game
{
    public class GameStateHandler : IInitializable
    {
        private readonly FSM _fsm;
        private readonly Mediator _mediator;

        public GameStateHandler(FSM fsm, Mediator mediator)
        {
            _fsm = fsm;
            _mediator = mediator;
        }

        public void Initialize()
        {
            _fsm.AddState(new InitPause(_fsm));
            _fsm.AddState(new Pause(_fsm, _mediator));
            _fsm.AddState(new Play(_fsm));

            SetState<InitPause>();
        }

        public void SetState<T>() where T : State => 
            _fsm.SetState<T>();
    }
}