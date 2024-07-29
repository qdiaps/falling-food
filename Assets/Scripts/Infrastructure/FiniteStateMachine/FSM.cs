using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.FiniteStateMachine
{
    public class FSM
    {
        public State CurrentState { get; private set; }

        private readonly Dictionary<Type, State> _states = new();

        public void AddState(State state)
        {
            if (_states.TryGetValue(state.GetType(), out var s))
                Debug.LogWarning($"Состояние {state.GetType()} уже есть в FSM.");
            else
                _states.Add(state.GetType(), state);
        }

        public void SetState<T>() where T : State
        {
            var type = typeof(T);
            if (type == CurrentState?.GetType())
                Debug.LogWarning("Происходит смена состояние на такое какое и было.");
            else if (_states.TryGetValue(type, out var newState))
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentState.Enter();
            }
            else
                Debug.LogWarning($"Нету такого состояния {type} в FSM.");
        }
    }
}