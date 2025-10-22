using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FSM {
    public class StateMachine:IStateMachine
    {
        private List<IState> _states;
        private string _defaultStateName;
        private IState _currentState;

        public UnityEvent<IState> OnStateChanged=new UnityEvent<IState>();

        public StateMachine(List<IState> states, string defaultStateName)
        {
            _states = states;
            _defaultStateName = defaultStateName;
        }

        #region IStateMachine
        public void Initialize()
        {
            EnterState(_defaultStateName);
        }
        public void AddState(IState state)
        {
            _states.Add(state);
        }
        public bool EnterState(string newStateName)
        {
            if (_currentState != null)
            {
                if (_currentState.GetName().Equals(newStateName))
                {
                    return false;
                }
                _currentState.OnExit();
            }

            _currentState = _states.Find(state => state.GetName() == newStateName);
            if (_currentState==null) {
                Debug.LogError($"StateMachine: State '{newStateName}' not found!");
                return false;
            }

            _currentState.OnEnter();
            OnStateChanged?.Invoke(_currentState);
            return true;
        }
        public IState GetCurrentState()
        {
            return _currentState;
        }
        public string GetCurrentStateName()
        {
            return _currentState.GetName();
        }
        public void OverrideState(IState state)
        {
            int index = _states.FindIndex(s => s.GetName() == state.GetName());
            if (index==-1)
            {
                AddState(state);
            }
            else
            {
                _states[index] = state;
            }
        }

        public void RemoveState(IState state)
        {
            int index = _states.FindIndex(s => s.GetName() == state.GetName());
            if (index == -1)
            {
                return;
            }
            else
            {
                _states.RemoveAt(index);
            }
        }
        public void StateUpdate()
        {
            if (_currentState != null)
            {
                if (_currentState.OnConditionUpdate(this))
                {
                    return;
                }
                _currentState.OnUpdate();
            }
        }

        #endregion

    }
}

