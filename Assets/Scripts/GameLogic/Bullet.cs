// Roman Baranov 11.05.2022

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private int _damage = 1;

    private float _lifetime = 4f;
    private float _curTime = 0f;
    #endregion

    #region UNITY Methods
    private void Update()
    {
        _curTime += Time.deltaTime;
        if (_curTime > _lifetime)
        {
            _curTime = 0f;
            BulletsPool.Instance.ResetBullet(gameObject);
        }
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        Health enemy = other.gameObject.GetComponent<Health>();
        if (enemy)
        {
            // Damage agent
            enemy.GetDamage(_damage);
        }

        // Return bullet in the pool
        _curTime = 0f;
        BulletsPool.Instance.ResetBullet(gameObject);
    }
}
