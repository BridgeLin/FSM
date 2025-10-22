# FSM
This is a finite-state machine system for Unity which is flexible and easy to use.
## Features
- Introduced a Lightweight Finite State Machine (FSM) System that allows users to create, modify, and invoke states.
- Designed for fast integration — no additional setup required.
- Enables intuitive state transitions and flexible runtime control for behavior management.
## How to use
### Install
- Open your Unity project.
- Window> Package Management> Package Manager
- Click "Install from git URL" and input https://github.com/BridgeLin/FSM.git
### Initialization
Create a state machine in your script and all states at the beginning.
``` C#
using FSM;
public class Player{
  priavte IStateMachine _stateMachine;
  private void InitializeStateMachine()
  {
      //public StateMachine(List<IState> states, string defaultStateName, IState anyState=null)
      //"states" is the containter of states.
      //"defaultStateName" is the name of the default state.
      //"anyState" is optional, its OnConditionUpdate and OnUpdate will be triggered prior to any current state.
      _stateMachine = new StateMachine(new List<IState>(), STATE_IDLE, new State("Any", conditions:new Condition[] {new Condition() }));
      _stateMachine.Initialize();
  }

}
```

