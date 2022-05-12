// Roman Baranov 11.05.2022

using UnityEngine;

public class AI_MoveToWaypointState : AI_State
{
    #region STATES
    public AI_StateId GetId()
    {
        return AI_StateId.MoveToWaypoint;
    }

    public void Enter(AI_Agent agent)
    {
        // Get next free waypoint node position
        agent.CurrentNode = LevelWaypoints.Instance.GetNextWaypoint();
        Transform waypointPosition = agent.CurrentNode.WaypointPosition;

        if (!waypointPosition)
        {
            Debug.Log("No waypoint nodes, Idling");
            agent.StateMachine.ChangeState(AI_StateId.Idle);
            return;
        }

        // Move to waypoint node position
        agent.NavMeshAgent.SetDestination(waypointPosition.position);
    }

    public void Update(AI_Agent agent)
    {
        // Player reached waypoint
        if (agent.NavMeshAgent.remainingDistance <= 0.01f)
        {
            // Switch to encounter state
            agent.StateMachine.ChangeState(AI_StateId.WaypointEncounter);
            return;
        }
    }

    public void Exit(AI_Agent agent)
    {
    }
    #endregion
}
