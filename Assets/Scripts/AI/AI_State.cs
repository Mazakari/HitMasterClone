// Roman Baranov 24.12.2021

#region ENUM
/// <summary>
/// Available character AI states
/// </summary>
public enum AI_StateId
{
    Idle,
    MoveToWaypoint,
    WaypointEncounter,
    Death
}
#endregion

#region INTERFACE
public interface AI_State
{
    /// <summary>
    /// Get current state Id
    /// </summary>
    /// <returns>Return current state</returns>
    public AI_StateId GetId();

    /// <summary>
    /// New state to enter
    /// </summary>
    /// <param name="agent"></param>
    public void Enter(AI_Agent agent);

    /// <summary>
    /// Update current state
    /// </summary>
    /// <param name="agent"></param>
    public void Update(AI_Agent agent);

    /// <summary>
    /// Exit current state
    /// </summary>
    /// <param name="agent"></param>
    public void Exit(AI_Agent agent);
}
#endregion
