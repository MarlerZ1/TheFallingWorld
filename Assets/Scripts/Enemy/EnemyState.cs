using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyPatrol))]
public class EnemyState : MonoBehaviour
{
    private EnemyPatrol _enemyPatrol;
    private EnemyNearChasing _enemyNearChasing;
     private EnemyDistantAttack _enemyDistantAttack;

    private string _enemyState = "Running";
    private Animator _animator;
    private Health _health;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyPatrol = GetComponent<EnemyPatrol>();
        _enemyNearChasing = GetComponent<EnemyNearChasing>();
        _enemyDistantAttack = GetComponent<EnemyDistantAttack>();
        _rb = GetComponent<Rigidbody2D>();

        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.OnDeath += EnemyDeath;
    }

    private void OnDisable()
    {
        _health.OnDeath -= EnemyDeath;
    }

    public void EnemyIdle()
    {
        _enemyState = "Idle";
        _animator.SetBool("isIdle", true);
        _animator.SetBool("isWalking", false);
        _rb.isKinematic = false;
    }

    public void EnemyWalking()
    {
        _enemyState = "Running";
        _animator.SetBool("isIdle", false);
        _animator.SetBool("isWalking", true);
        _enemyPatrol.enabled = true;
        _rb.isKinematic = false;
        if (_enemyNearChasing)
            _enemyNearChasing.enabled = false;
        if (_enemyDistantAttack)
            _enemyDistantAttack.enabled = false;
    }

    public void EnemyChasing()
    {
        _enemyState = "Chasing";
        _animator.SetBool("isIdle", false);
        _animator.SetBool("isWalking", true);
        _enemyPatrol.enabled = false;
        _rb.isKinematic = false;
        if (_enemyNearChasing)
            _enemyNearChasing.enabled = true;
        else
            EnemyFire();
    }

    public void EnemyDeath(bool authoDestroy)
    {
        _enemyState = "Death";
        _animator.SetBool("isDeath", true);
        _animator.SetBool("isWalking", false);
        _enemyPatrol.enabled = false;
        if (_enemyNearChasing)
            _enemyNearChasing.enabled = false;

        if (_enemyDistantAttack)
            _enemyDistantAttack.enabled = false;

        _rb.velocity = Vector2.zero;
        _rb.isKinematic = true;

    }


    public void EnemyFire()
    {
        _enemyState = "Chasing";
        _animator.SetBool("isIdle", false);
        _animator.SetBool("isWalking", false);
        _animator.SetTrigger("isFire");
        _enemyPatrol.enabled = false;
        _rb.velocity = Vector2.zero;

        if (_enemyDistantAttack)
            _enemyDistantAttack.enabled = true;
    }


    public string GetEnemyState()
    {
        return _enemyState;
    }
}
