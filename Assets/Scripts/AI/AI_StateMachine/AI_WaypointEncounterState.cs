// Roman Baranov 11.05.2022

using UnityEngine;

public class AI_WaypointEncounterState : AI_State
{
    #region STATES
    public AI_StateId GetId()
    {
        return AI_StateId.WaypointEncounter;
    }
    public void Enter(AI_Agent agent)
    {
        // Activates shoot input
        if (agent.CurrentNode.FinishNode)
        {
            GameplayEvents.OnLevelComplete.Invoke();
        }
    }
    public void Update(AI_Agent agent)
    {
        if (agent.CurrentNode.IsCleared)
        {
            agent.StateMachine.ChangeState(AI_StateId.MoveToWaypoint);
            return;
        }
    }

    public void Exit(AI_Agent agent)
    {
    }
    #endregion
}
