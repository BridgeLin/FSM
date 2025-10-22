namespace FSM {
    public interface IState
    {
        /// <summary>
        /// Entering this state, this method will be triggered.
        /// </summary>
        public void OnEnter();

        /// <summary>
        /// Exiting this state, this method will be triggered. 
        /// </summary>
        public void OnExit();

        /// <summary>
        /// Checks if the condition for a state transition is met.
        /// If true, switches the state machine to the corresponding target state.
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        public bool OnConditionUpdate(IStateMachine stateMachine);

        /// <summary>
        /// Updates this state.
        /// </summary>
        public void OnUpdate();

        /// <summary>
        /// Gets the name of this state.
        /// </summary>
        /// <returns></returns>
        public string GetName();

    }
}

