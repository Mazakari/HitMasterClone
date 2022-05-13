// Roman Baranov 11.05.2022

using UnityEngine;

/// <summary>
/// Contains information and objects related to waypoint node. 
/// Enemies collection, player waypoint position and if waypoint has been cleared
/// </summary>
public class WaypointNode : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private bool _finishNode = false;
    /// <summary>
    /// Is this node a finish one
    /// </summary>
    public bool FinishNode { get { return _finishNode; } }

    [Header("Waypoint position for player character")]
    [SerializeField] private Transform _waypointPosition = null;
    /// <summary>
    /// Waypoint position for player
    /// </summary>
    public Transform WaypointPosition { get { return _waypointPosition; } }

    private AI_Agent[] _enemies = null;
    /// <summary>
    /// Waypoint enemies collection
    /// </summary>
    public AI_Agent[] Enemies { get { return _enemies; } }

    private bool _isCleared = false;
    /// <summary>
    /// Is waypoint has been cleared
    /// </summary>
    public bool IsCleared { get { return _isCleared; } }

    private int _enemyRemains = 0;
    /// <summary>
    /// Remaining enemies in the node
    /// </summary>
    public int EnemyRemains { get { return _enemyRemains; } set { _enemyRemains = value; } }

    /// <summary>
    /// Is this waypoint node encountered by player at the moment
    /// </summary>
    public bool IsEncountered { get; set; } = false;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    private void Start()
    {
        if (_waypointPosition == null)
        {
           
            Debug.LogError($"{gameObject.name}: Waypoint position is NULL");
        }

        if (_finishNode)
        {
            return;
        }

        InitEnemies();

        // Listen for dead enemy callback
        GameplayEvents.OnEnemyDead.AddListener(UpdateEnemyCount);
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Get all waypoint enemies into collection
    /// </summary>
    private void InitEnemies()
    {
        _enemies = GetComponentsInChildren<AI_Agent>();

        if (_enemies == null || _enemies.Length == 0)
        {
            Debug.LogError($"{gameObject.name}: Enemies collection is NULL or empty");
            _isCleared = true;
            return;
        }
        _enemyRemains = _enemies.Length;

        for (int i = 0; i < _enemies.Length; i++)
        {
            _enemies[i].CurrentNode = this;
        }
        _isCleared = false;
        IsEncountered = false;
    }

    /// <summary>
    /// Check if dead enemy belong to the waypoint node
    /// </summary>
    /// <param name="enemy">Dead enemy</param>
    private void UpdateEnemyCount(AI_Agent enemy)
    {
        if (Object.ReferenceEquals(enemy.CurrentNode, this))
        {
            if (_enemyRemains > 0)
            {
                _enemyRemains--;

                // Check if there are enemies left
                if (_enemyRemains == 0)
                {
                    _isCleared = true;
                }
            }
        }
    }
    #endregion
}
