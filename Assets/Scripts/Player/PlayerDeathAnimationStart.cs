using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(PlayerAnimationState))]
public class PlayerDeathAnimationStart : MonoBehaviour
{
    private Health _playerHealth;
    private PlayerAnimationState _playerAnimationState;
    private void Awake()
    {
        _playerHealth = GetComponent<Health>();
        _playerAnimationState = GetComponent<PlayerAnimationState>();
    }


    private void OnDisable()
    {
        _playerHealth.OnDeath -= StartDeathAnimation;
    }

    private void OnEnable()
    {
        _playerHealth.OnDeath += StartDeathAnimation;
    }

    private void StartDeathAnimation(bool authoDestroy)
    {
        _playerAnimationState.HeroDeath();
    }
}
