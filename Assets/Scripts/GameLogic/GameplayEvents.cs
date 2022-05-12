// Roman Baranov 11.05.2022

using UnityEngine;
using UnityEngine.Events;

public static class GameplayEvents
{
    /// <summary>
    /// Callback sent on enemy get damage. Pass damaged enemy GameObject on Invoke
    /// </summary>
    public static readonly UnityEvent<GameObject> OnEnemyDamaged = new UnityEvent<GameObject>();

    /// <summary>
    /// Callback sent on enemy dead. Pass dead enemy GameObject on Invoke
    /// </summary>
    public static readonly UnityEvent<AI_Agent> OnEnemyDead = new UnityEvent<AI_Agent>();

    /// <summary>
    /// Callback sent on player shot
    /// </summary>
    public static readonly UnityEvent OnPlayerShoot = new UnityEvent();

    /// <summary>
    /// Callback sent on level completion
    /// </summary>
    public static readonly UnityEvent OnLevelComplete = new UnityEvent();
}
