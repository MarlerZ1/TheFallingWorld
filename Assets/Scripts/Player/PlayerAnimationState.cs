using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMoving))]
[RequireComponent(typeof(PlayerAttack))]

public class PlayerAnimationState : MonoBehaviour
{
    private Animator _animator;
    private PlayerMoving _playerMoving;
    private PlayerAttack _playerAttack;
    private Rigidbody2D _rb;

    private string _currentState = "Idle";

    public string GetState()
    {
        return _currentState;
    }

    private void Awake()
    {
        _playerMoving = GetComponent<PlayerMoving>();
        _playerAttack = GetComponent<PlayerAttack>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    public void HeroRun()
    {
        _currentState = "Run";
        _animator.SetBool("isRunning", true);
    }


    public void HeroIdle()
    {
        _currentState = "Idle";
        _animator.SetBool("isRunning", false);
    }


    public void HeroDeath()
    {
        _currentState = "Death";
        _animator.SetTrigger("isDeath");
        _playerMoving.enabled = false;
        _playerAttack.enabled = false;
        _rb.gravityScale = 0;
        _rb.velocity = Vector3.zero;
    }
}
