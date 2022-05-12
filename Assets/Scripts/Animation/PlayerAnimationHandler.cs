// Roman Baranov 11.05.2022

using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimationHandler : MonoBehaviour
{
    #region VARIABLES
    private NavMeshAgent _agent = null;
    private Animator _animator = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
        GameplayEvents.OnPlayerShoot.AddListener(PlayShootAnimation);
    }

    // Update is called once per frame
    private void Update()
    {
        _animator.SetFloat("Speed", _agent.velocity.magnitude);
    }
    #endregion

    #region PRIVATE Methods
    private void PlayShootAnimation()
    {
        _animator.SetTrigger("Shoot");
    }
    #endregion
}
