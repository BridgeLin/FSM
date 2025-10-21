using System;

namespace FSM {
    public class State : IState
    {
        private string _name;
        private Action _enterEvent;
        private Action _exitEvent;   
        private Condition[] _conditions;
        private Action _updateEvent;

        public State(string name,Action enterEvent = null, Action exitEvent = null, Condition[] conditions = null, Action updateEvent=null)
        {
            _name = name;
            _enterEvent = enterEvent;
            _exitEvent = exitEvent;
            _conditions = conditions;
            _updateEvent = updateEvent;
        }

        #region IState
        public string GetName()
        {
            return _name;
        }

        public void OnEnter()
        {
            if (_enterEvent == null) return;
            _enterEvent.Invoke();
        }

        public void OnExit()
        {
            if(_exitEvent == null) return;
            _exitEvent.Invoke();
        }

        public bool OnConditionUpdate(IStateMachine stateMachine)
        {
            if (_conditions == null) return false;

            foreach (var condition in _conditions)
            {
                if (condition.Invoke(out string target)) {
                    stateMachine.EnterState(target);
                    return true;
                }
            }

            return false;
        }
        public void OnUpdate()
        {
            if (_updateEvent == null) return;

            _updateEvent.Invoke();
        }
        #endregion
    }


    public struct Condition {
        private Func<bool> condition;
        private string targetStateName;
        public Condition(string targetStateName,Func<bool> condition)
        {
            this.condition = condition;
            this.targetStateName = targetStateName;
        }

        public bool Invoke(out string target) {
            target = targetStateName;
            return condition.Invoke();
        }
    }
}

