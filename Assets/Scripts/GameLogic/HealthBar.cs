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

        GameplayEvents.OnEnemyDamaged.AddListener(UpdateHeathBar);
        GameplayEvents.OnEnemyDead.AddListener(DeactivateHealthBar);
    }
    #endregion

    #region PRIVATE Methods
    private void UpdateHeathBar(GameObject go)
    {
        if (go.Equals(gameObject.transform.parent))
        {
            _healthBar.value = _health.CurHealth;
        }
    }

    private void DeactivateHealthBar(AI_Agent agent)
    {
        if (agent.gameObject.name.Equals(gameObject.transform.parent.name))
        {
            gameObject.SetActive(false);
        }
    }
    #endregion

}
