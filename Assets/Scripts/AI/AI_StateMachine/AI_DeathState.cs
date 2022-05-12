// Roman Baranov 27.12.2021

using UnityEngine;

public class AI_DeathState : AI_State
{
    #region STATES
    public AI_StateId GetId()
    {
        return AI_StateId.Death;
    }

    public void Enter(AI_Agent agent)
    {
        Animator a = agent.GetComponent<Animator>();

        // Send death callback
        GameplayEvents.OnEnemyDead.Invoke(agent);

        // Activate enemy ragdoll
        a.enabled = false;
    }

    public void Update(AI_Agent agent)
    {
        //Debug.Log("AI_DeathState.Update");
    }

    public void Exit(AI_Agent agent)
    {
        //Debug.Log("AI_DeathState.Exit");
    }
    #endregion
}
