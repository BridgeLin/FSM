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
Create a state with its name, on enter action, on exit action, conditions and update action.
``` C#
using FSM;
public class Player{
  private IState InitState_Idle()
  {
      return new State("idle",
              enterEvent: () => { },
              exitEvent: () => { },
              conditions: new Condition[] { new Condition("moving",()=> _isMoving) },
              updateEvent: () => { }
          );
  }
}
```
Create a state machine in your script and all states.
``` C#
priavte IStateMachine _stateMachine;
  private void InitializeStateMachine()
  {
      //public StateMachine(List<IState> states, string defaultStateName, IState anyState=null)
      //"states" is the containter of states.
      //"defaultStateName" is the name of the default state.
      //"anyState" is optional, its OnConditionUpdate and OnUpdate will be triggered prior to any current state.
      _stateMachine = new StateMachine(new List<IState>(), "idle", new State("Any", conditions:new Condition[] {new Condition() }));
      _stateMachine.AddState(InitState_Idle());//Remember the default state should be added into the state machine before .Initialize().
      _stateMachine.Initialize();
  }
```
## Documentation
### Interface
#### IState
##### Defination
``` C#
public interface IState
```
##### Public Methods
|Method |Return|Description|
|-|-|-|
|OnEnter()|void|Be executed every time state machine enter this state.|
|OnExit()|void|Be executed every time state machine exit this state.|
|OnConditionUpdate(IStateMachine stateMachine)|bool|Checks every time this state updates. If the condition for a state transition is met, switches the state machine to the corresponding target state.|
|OnUpdate()|void|Be executed every time this state updates.|
|GetName()|string|Gets the name of this state.|
#### IStateMachine
##### Defination
``` C#
public interface IStateMachine
```
##### Public Methods
|Method |Return|Description|
|-|-|-|
|Initialize()|void|Initialize the state machine.|
|GetCurrentState()|IState|Get the current state.|
|GetCurrentStateName()|string|Get the name of the current state.|
|EnterState(string targetStateName)|bool|Forces the state machine to enter the specified target state. Returns false when the state machine is already in the state.|
|AddState(IState state)|void|Adds the state into this state machine.|
|OverrideState(IState state)|void|Overrides the existing state with the new one.|
|RemoveState(IState state)|void|Removes the state from this state machine.|
|StateUpdate()|void|This method can be called any moment of the game loop. Being called, the state machine will update the current state.|
### Class
#### State
##### Defination
``` C#
public class State : IState
```
##### Constructor
|Constructor |Description|
|-|-|
|```public State(string name, Action enterEvent = null, Action exitEvent = null, Condition[] conditions = null, Action updateEvent=null)```| Initializes a new instance of the ```State``` class that contains elements name, (optional) eneterEvent, (optional) exitEvent, (optional) conditions, (optional) updateEvent.|

#### StateMachine
##### Defination
``` C#
public class StateMachine:IStateMachine
```
##### Constructor
|Constructor|Description|
|-|-|
|```public StateMachine(List<IState> states, string defaultStateName, IState anyState=null)```|Initializes a new instance of the ```StateMachine``` class that contains states, name of the default state, (optional) any state.|

### Struct
#### Condition
##### Defination
Represents a transition condition within a finite state machine.
``` C#
public struct Condition
```
##### Constructor
|Constructor |Description|
|-|-|
|```public Condition(string targetStateName,Func<bool> condition)```|Initializes a new instance of the ```Condition``` struct.|
##### Public Method
|Method|Return|Description|
|-|-|-|
|Invoke(out string target)|bool|Evaluates the condition and outputs the target state name.|


