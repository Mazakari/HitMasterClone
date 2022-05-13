// Roman Baranov 01.05.2022

using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    #region VARIABLES
    public static BulletsPool Instance = null;

    [Header("Bullets Pool Settings")]
    [SerializeField] private int _poolSize = 10;

    [SerializeField] private Bullet _bulletPrefab = null;
    /// <summary>
    /// Bullets pool
    /// </summary>
    public List<Bullet> BulletPool { get; private set; } = new List<Bullet> ();
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        if (Instance)
        {
            Instance = null;
        }

        Instance = this;

        CreateBulletsPool();
    }
    #endregion

    #region PUBLIC Methods
    public Bullet GetBullet()
    {
        for (int i = 0; i < BulletPool.Count; i++)
        {
            if (!BulletPool[i].gameObject.activeSelf)
            {
                return BulletPool[i];
            }
        }

        return null;
    }
    /// <summary>
    /// Reset bullet position and return it in the pool
    /// </summary>
    /// <param name="bullet">Bullet to reset</param>
    public void ResetBullet(Bullet bullet)
    {
        // Deactivate bullet object
        bullet.gameObject.SetActive(false);

        bullet.RB.velocity = Vector3.zero;

        // Reset bullet position
        bullet.transform.position = transform.position;
        bullet.transform.SetParent(transform);
    }
    #endregion

    #region PRIVATE Methods
    /// <summary>
    /// Spawn bullets pool
    /// </summary>
    private void CreateBulletsPool()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            Bullet bullet = Instantiate(_bulletPrefab, gameObject.transform);
            bullet.gameObject.SetActive(false);

            BulletPool.Add(bullet);
        }
    }
    #endregion
} 

