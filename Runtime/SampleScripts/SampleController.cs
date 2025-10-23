using FSM;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace FSM_Sample
{
    public class SampleController : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _txtCurrentState;
        [SerializeField] private TextMeshProUGUI _txtHp;

        private StateMachine _stateMachine;
        private bool _isMoving = false;
        private int _currentHp = 3;

        private const string STATE_IDLE = "idle";
        private const string STATE_MOVING = "moving";
        private const string STATE_DIE = "die";
        private const string STATE_ANY = "any";


        private void InitializeStateMachine()
        {
            _stateMachine = new StateMachine(new List<IState>(), STATE_IDLE,
                new State(STATE_ANY, conditions:new Condition[] {new Condition(STATE_DIE, () => _currentHp <= 0) }));
            
            _stateMachine.AddState(InitState_Idle());
            _stateMachine.AddState(InitState_Moving());
            _stateMachine.AddState(InitState_Die());
            _stateMachine.OnStateChanged.AddListener((IState state) => {
                _txtCurrentState.text= $"Player State: {state.GetName()}";
            });
            _stateMachine.Initialize();
        }


        private IState InitState_Idle()
        {
            return new State(STATE_IDLE,
                    enterEvent: () => { },
                    exitEvent: () => { },
                    conditions: new Condition[] { new Condition(STATE_MOVING,()=> _isMoving) },
                    updateEvent: () => { }
                );
        }

        private IState InitState_Moving()
        {
            return new State(STATE_MOVING,
                    enterEvent: () => { },
                    exitEvent: () => { },
                    conditions: new Condition[] { new Condition(STATE_IDLE,()=>!_isMoving) },
                    updateEvent: () => { }
                );
        }

        private IState InitState_Die()
        {
            return new State(STATE_DIE,
                    enterEvent: () => { },
                    exitEvent: () => { },
                    conditions: new Condition[] { new Condition(STATE_IDLE,()=>_currentHp>0) },
                    updateEvent: () => { }
                );
        }

        #region MonoBehaviour
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            InitializeStateMachine();
            _txtHp.text = $"Player HP: {_currentHp}";
        }

        // Update is called once per frame
        void Update()
        {
            _stateMachine.StateUpdate();
        }
        #endregion

        #region Others
        public void AddHp(int n)
        {
            _currentHp += n;

            if (_currentHp<0)
            {
                _currentHp = 0;
            }

            _txtHp.text = $"Player HP: {_currentHp}";
        }

        public void Run(bool flag)
        {
            _isMoving = flag;
        }
        #endregion


    }
}

