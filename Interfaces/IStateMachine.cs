using UnityEngine;


namespace FSM {
    public interface IStateMachine
    {
        public void Initialize();
        public IState GetCurrentState();
        public string GetCurrentStateName();
        public bool EnterState(string newStateName);

        public void AddState(IState state);
        public void OverrideState(IState state);
        public void StateUpdate();
    }
}

