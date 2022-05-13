// Roman Baranov 11.05.2022

using UnityEngine;

[RequireComponent(typeof(AI_Agent))]
public class Health : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private int _maxHealth = 4;
    /// <summary>
    /// Max health value
    /// </summary>
    public int MaxHealth { get { return _maxHealth; } }

    private int _curHealth;
    /// <summary>
    /// Current Health value
    /// </summary>
    public int CurHealth { get { return _curHealth; } }

    private AI_Agent _agent = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<AI_Agent>();  
        _curHealth = _maxHealth;
    }
    #endregion

    #region PUBLUC Methods
    public void GetDamage(int damage)
    {
        _curHealth -= damage;
        // Invoke event to play get hit animation
        GameplayEvents.OnEnemyDamaged.Invoke(gameObject);

        if (_curHealth <= 0)
        {
            _curHealth = 0;
            _agent.StateMachine.ChangeState(AI_StateId.Death);
        }
    }
    #endregion
}
