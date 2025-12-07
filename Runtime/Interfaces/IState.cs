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


        #region Override Methods
        public void OverrideEnterEvent(System.Action newEnterEvent);
        public void OverrideExitEvent(System.Action newExitEvent);
        public void OverrideConditions(Condition[] newConditions);
        public void OverrideUpdateEvent(System.Action newUpdateEvent);
        #endregion


        #region Add Methods
        public void AddEnterEvent(System.Action additionalEnterEvent);
        public void AddExitEvent(System.Action additionalExitEvent);
        public void AddConditions(Condition additionalConditions);
        public void AddUpdateEvent(System.Action additionalUpdateEvent);
        #endregion
    }
}

