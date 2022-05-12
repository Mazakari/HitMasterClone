// Roman Baranov 01.05.2022

using System.Collections.Generic;
using UnityEngine;

public class BulletsPool : MonoBehaviour
{
    #region VARIABLES
    public static BulletsPool Instance = null;

    [Header("Bullets Pool Settings")]
    [SerializeField] private int _poolSize = 10;

    [SerializeField] private GameObject _bulletPrefab = null;
    /// <summary>
    /// Bullets pool
    /// </summary>
    public List<GameObject> BulletPool { get; private set; } = new List<GameObject> ();
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
    public GameObject GetBullet()
    {
        for (int i = 0; i < BulletPool.Count; i++)
        {
            if (!BulletPool[i].activeSelf)
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
    public void ResetBullet(GameObject bullet)
    {
        // Deactivate bullet object
        bullet.SetActive(false);

        bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;

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
            GameObject bullet = Instantiate(_bulletPrefab, gameObject.transform);
            bullet.gameObject.SetActive(false);

            BulletPool.Add(bullet.gameObject);
        }
    }
    #endregion
} 

