// Roman Baranov 11.05.2022

using UnityEngine;

public class EnemyAnimationHandler : MonoBehaviour
{
    #region VARIABLES
    private Animator _animator = null;
    #endregion

    #region UNITY Methods
    // Start is called before the first frame update
    void Start()
    {
        GameplayEvents.OnEnemyDamaged.AddListener(PlayGetHitAnimation);
        _animator = GetComponent<Animator>();
    }
    #endregion

    #region EVENT HANDLER Methods
    private void PlayGetHitAnimation(GameObject enemy)
    {
        if (enemy.Equals(gameObject))
        {
            _animator.SetTrigger("isHit");
        }
    }
    #endregion

}
