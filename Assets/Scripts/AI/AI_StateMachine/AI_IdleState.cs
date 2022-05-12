// Roman Baranov 11.05.2022

using UnityEngine;

public class AI_IdleState : AI_State
{
    public AI_StateId GetId()
    {
        return AI_StateId.Idle;
    }

    public void Enter(AI_Agent agent)
    {
        //Debug.Log("AI_IdleState.Enter");
    }

    public void Update(AI_Agent agent)
    {
    }
    public void Exit(AI_Agent agent)
    {
    }
}
