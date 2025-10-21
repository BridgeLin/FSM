using UnityEngine;

namespace FSM {
    public interface IState
    {
        public void OnEnter();
        public void OnExit();

        public bool OnConditionUpdate(IStateMachine stateMachine);
        public void OnUpdate();

        public string GetName();

    }
}

