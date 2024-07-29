namespace Infrastructure.FiniteStateMachine
{
    public abstract class State
    {
        protected readonly FSM _fsm;
        
        public State(FSM fsm) => 
            _fsm = fsm;

        public virtual void Enter() { }
        
        public virtual void Exit() { }
    }
}