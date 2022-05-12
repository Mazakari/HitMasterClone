// Roman Baranov 11.05.2022

using System.Collections.Generic;
using UnityEngine;

public class LevelWaypoints : MonoBehaviour
{
    #region VARIABLES
    public static LevelWaypoints Instance;

    [Header("Level Waypoints Collection")]
    [SerializeField] private List<WaypointNode> _waypoints = null;
    /// <summary>
    /// Level waypoints collection
    /// </summary>
    public List<WaypointNode> Waypoints { get { return _waypoints; } }
    #endregion

    #region UNITY Methods
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (_waypoints == null || _waypoints.Count == 0)
        {
            Debug.LogError($"{gameObject.name}: Waypoints collection is NULL or empty!");
        }
    }
    #endregion

    #region PUBLIC Methods
    /// <summary>
    /// Look for next free waypoint
    /// </summary>
    /// <returns>Waypoint node referrence</returns>
    public WaypointNode GetNextWaypoint()
    {
        for (int i = 0; i < _waypoints.Count; i++)
        {
            if (_waypoints[i].IsCleared == false)
            {
                return _waypoints[i];
            }
        }

        Debug.Log("No free waypoint nodes found!");
        return null;
    }
    #endregion
}
