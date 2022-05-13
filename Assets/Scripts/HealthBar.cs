// Roman Baranov 12.05.2022

using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private Slider _healthBar = null;
    [SerializeField] private Health _health = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        _healthBar.wholeNumbers = true;
        _healthBar.minValue = 0;
        _healthBar.maxValue = _health.MaxHealth;
        _healthBar.value = _healthBar.maxValue;

        // Subscribe on enemy status events
        GameplayEvents.OnEnemyDamaged.AddListener(UpdateHeathBar);
        GameplayEvents.OnEnemyDead.AddListener(DeactivateHealthBar);
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Updates health bar value on callback
    /// </summary>
    /// <param name="go">Callback sender</param>
    private void UpdateHeathBar(GameObject go)
    {
        if (Object.ReferenceEquals(go.gameObject, _health.gameObject))
        {
            _healthBar.value = _health.CurHealth;
        }
    }

    /// <summary>
    /// Deactivates healthbar on the parent game object death
    /// </summary>
    /// <param name="agent">Callback sender</param>
    private void DeactivateHealthBar(AI_Agent agent)
    {
        if (Object.ReferenceEquals(agent.gameObject, _health.gameObject))
        {
            gameObject.SetActive(false);
        }
    }
    #endregion

}
