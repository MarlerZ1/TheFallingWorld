using System.Collections;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(EnemyState))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyPatrol : MonoBehaviour
{
    [Header("RayCast settings")]
    [SerializeField] private float rayCastDistance;
    [SerializeField] private Transform groundRaycastPointFirst;
    [SerializeField] private Transform groundRaycastPointSecond;
    [SerializeField] private LayerMask layerMask;


    [Header("Moving settings")]
    [SerializeField] private float speed;
    [SerializeField] private float timeToIdleState;

    private int _direction = 1;
    private Rigidbody2D _rb;
    private Animator _animator;
    private EnemyState _enemyState;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _enemyState = GetComponent<EnemyState>();

    }
    private void Start()
    {
        _enemyState.EnemyWalking();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(groundRaycastPointFirst.position, Vector3.down * rayCastDistance, Color.yellow);
        Debug.DrawRay(groundRaycastPointSecond.position, Vector3.down * rayCastDistance, Color.red);


        _rb.velocity = new Vector2(_direction * speed, _rb.velocity.y);
        
        if (_enemyState.GetEnemyState() != "Idle" && !Physics2D.Raycast(groundRaycastPointFirst.position, Vector2.down, rayCastDistance, layerMask) &&
            !Physics2D.Raycast(groundRaycastPointSecond.position, Vector2.down, rayCastDistance, layerMask))
        {
            StartCoroutine(IEPlayIdleAnimation());
        }
    }

    public IEnumerator IEPlayIdleAnimation()
    {
        _enemyState.EnemyIdle();
        _direction = 0;

        yield return new WaitForSeconds(timeToIdleState);
       
        _enemyState.EnemyWalking();
        ChangeDirection();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layerMask.Contains(collision.gameObject.layer) && _enemyState.GetEnemyState() != "Chasing")
        {
            StartCoroutine(IEPlayIdleAnimation());
        }
    }


    private void ChangeDirection()
    {
        _direction = transform.rotation.y == -1 ? 1 : -1; 
        bool rotationFlag = transform.rotation.y == -1;
        transform.rotation = Quaternion.Euler(0, rotationFlag ? 0 : 180, 0);
    }
    private void OnEnable()
    {
        _direction = transform.rotation.y == -1 ? -1 : 1;

        if (Physics2D.OverlapCircle(transform.position, 0.8F, layerMask))
        {
            StartCoroutine(IEPlayIdleAnimation());
        }


    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
