namespace FSM {
    public interface IState
    {
        /// <summary>
        /// Be executed every time state machine enter this state.
        /// </summary>
        public void OnEnter();

        /// <summary>
        /// Be executed every time state machine exit this state.
        /// </summary>
        public void OnExit();

        /// <summary>
        /// Checks every time this state updates.
        /// If the condition for a state transition is met, switches the state machine to the corresponding target state.
        /// </summary>
        /// <param name="stateMachine"></param>
        /// <returns></returns>
        public bool OnConditionUpdate(IStateMachine stateMachine);

        /// <summary>
        /// Be executed every time this state updates.
        /// </summary>
        public void OnUpdate();

        /// <summary>
        /// Gets the name of this state.
        /// </summary>
        /// <returns></returns>
        public string GetName();

        /// <summary>
        /// Check if the state can be exited.
        /// </summary>
        /// <returns></returns>
        public bool KeepStaying();

    }
}

