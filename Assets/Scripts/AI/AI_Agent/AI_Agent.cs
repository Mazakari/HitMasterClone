// Roman Baranov 11.05.2022

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AI_Agent : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private AI_StateId _initialState;

    private AI_StateMachine _stateMachine = null;
    /// <summary>
    /// Agent's state machine referrence
    /// </summary>
    public AI_StateMachine StateMachine { get { return _stateMachine; } }

    private NavMeshAgent _navMeshAgent = null;

    /// <summary>
    /// NavMeshAgent component of the game object
    /// </summary>
    public NavMeshAgent NavMeshAgent { get { return _navMeshAgent; } }

    /// <summary>
    /// Waypoint Node currently encountered
    /// </summary>
    public WaypointNode CurrentNode { get; set; }
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();

        // State machine
        _stateMachine = new AI_StateMachine(this);
        _stateMachine.RegisterState(new AI_IdleState());
        _stateMachine.RegisterState(new AI_MoveToWaypointState());
        _stateMachine.RegisterState(new AI_WaypointEncounterState());
        _stateMachine.RegisterState(new AI_DeathState());

        _stateMachine.ChangeState(_initialState);
    }

    // Update is called once per frame
    private void Update()
    {
        _stateMachine.Update();
    }
    #endregion
}
