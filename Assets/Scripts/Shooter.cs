// Roman Baranov 11.05.2022

using UnityEngine;

public class Shooter : MonoBehaviour
{
    #region VARIABLES
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _gunBarrel = null;
    [SerializeField] private float _fireDelay = 2f;

    private float _fireTimer = 0f;
    private bool _shootTimerActive = false;
    private float _shootDistance = 50f;

    [SerializeField] private float _bulletSpeed = 1f;

    private AI_Agent _agent;
    #endregion

    #region UNITY Methods
    private void Start()
    {
        _agent = GetComponent<AI_Agent>();
    }
    // Update is called once per frame
    void Update()
    {
        // Allow to shoot only if player in waypoint encounter state
        if (_agent.StateMachine.currentState == AI_StateId.WaypointEncounter)
        {
            // Shoot delay timer
            if (_shootTimerActive)
            {
                _fireTimer += Time.deltaTime;
                if (_fireTimer >= _fireDelay)
                {
                    _fireTimer = 0f;
                    _shootTimerActive = false;
                }

                return;
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out RaycastHit hitInfo, _shootDistance, _layerMask))
                    {
                        // Rotate player to the target
                        gameObject.transform.LookAt(hitInfo.point);

                        Shoot(hitInfo.point);
                        GameplayEvents.OnPlayerShoot.Invoke();

                        return;
                    }
                }
            }
        }
    }

    #endregion

    #region PUBLIC Methods
    /// <summary>
    /// Shoot bullet in the given direction
    /// </summary>
    /// <param name="target">Bullet target</param>
    public void Shoot(Vector3 target)
    {
        GameObject bullet = BulletsPool.Instance.GetBullet();
        if (bullet != null)
        {
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb)
            {
                bullet.transform.position = _gunBarrel.position;
                Vector3 direction = target - _gunBarrel.position;
                bullet.SetActive(true);

                rb.AddForce(direction * _bulletSpeed, ForceMode.Impulse);
                _shootTimerActive = true;
            }
        }
    }
    #endregion
}
