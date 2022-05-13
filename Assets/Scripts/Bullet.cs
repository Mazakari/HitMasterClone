// Roman Baranov 11.05.2022

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private int _damage = 1;
    [SerializeField] private Rigidbody _rigidbody = null;
    /// <summary>
    /// Bullet rigidbody comonent referrence
    /// </summary>
    public Rigidbody RB { get { return _rigidbody; } }

    private float _lifetime = 2f;
    private float _curTime = 0f;
    #endregion

    #region UNITY Methods
    private void Update()
    {
        _curTime += Time.deltaTime;
        if (_curTime > _lifetime)
        {
            _curTime = 0f;
            BulletsPool.Instance.ResetBullet(this);
        }
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        AI_Agent agent = other.gameObject.GetComponent<AI_Agent>();
        if (!agent.CurrentNode.IsEncountered) 
        { 
            return; 
        }

        Health enemy = other.gameObject.GetComponent<Health>();
        if (enemy)
        {
            // Damage agent
            enemy.GetDamage(_damage);
        }

        // Return bullet in the pool
        _curTime = 0f;
        BulletsPool.Instance.ResetBullet(this);
    }
}
