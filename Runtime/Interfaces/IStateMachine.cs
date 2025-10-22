namespace FSM {
    public interface IStateMachine
    {
        /// <summary>
        /// Initialize the state machine.
        /// </summary>
        public void Initialize();

        /// <summary>
        /// Get the currently active state.
        /// </summary>
        /// <returns></returns>
        public IState GetCurrentState();

        /// <summary>
        /// Get the name of the currently active state.
        /// </summary>
        /// <returns></returns>
        public string GetCurrentStateName();

        /// <summary>
        /// Forces the state machine to enter the specified target state. 
        /// </summary>
        /// <param name="targetStateName"></param>
        /// <returns></returns>
        public bool EnterState(string targetStateName);

        /// <summary>
        /// Adds the state into this state machine.
        /// </summary>
        /// <param name="state"></param>
        public void AddState(IState state);
        /// <summary>
        /// Overrides the state.
        /// </summary>
        /// <param name="state"></param>
        public void OverrideState(IState state);
        /// <summary>
        /// Removes the state from this state machine.
        /// </summary>
        /// <param name="state"></param>
        public void RemoveState(IState state);

        /// <summary>
        /// This method can be called at any moment of the game loop.
        /// Being called, the state machine will call the current state's OnConditionUpdate and OnUpdate.
        /// </summary>
        public void StateUpdate();
    }
}

