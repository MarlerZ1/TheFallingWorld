using UnityEngine;


[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyDistantAttack : MonoBehaviour
{
    [Header("Balance setting")]
    [SerializeField] private float coldownTime;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float distanceToEscape;
    [SerializeField] private float escapeSpeed;


    [Header("Supporting objects")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform player;
    [SerializeField] private Transform spawnPosition;


    private Rigidbody2D _rb;
    private bool isEscaping;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (player == null)
            return;

        if (Mathf.Abs(player.position.x - transform.position.x) <= distanceToEscape)
        {
            isEscaping = true;
            _rb.isKinematic = false;
            Vector2 newVelocity =  - new Vector2(player.position.x - transform.position.x, 0).normalized * escapeSpeed;
            newVelocity += new Vector2(0, _rb.velocity.y);
            _rb.velocity = newVelocity;

            _animator.SetBool("isIdle", false);
            _animator.SetBool("isWalking", true);

            RotateEnemy((player.position - spawnPosition.position).x < 0);
        }   
        else
        {
            isEscaping = false;
            _animator.SetBool("isIdle", false);
            _animator.SetBool("isWalking", false);
            _animator.SetTrigger("isFire");

            _rb.isKinematic = false;
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
    }


    private void RotateEnemy(bool rotationFlag)
    {
        transform.rotation = Quaternion.Euler(0, rotationFlag ? 0 : 180, 0);
    }

    public void Attack()
    {
        if (isEscaping || player == null)
            return;

        RotateEnemy((player.position - spawnPosition.position).x > 0);


        Vector2 shotDirection = (player.position - spawnPosition.position).normalized;

        GameObject magicBullet = Instantiate(bullet, spawnPosition.position, Quaternion.Euler(0, transform.rotation.y == -1 ? 180 : 0, 0));
        magicBullet.GetComponent<Bullet>().SetFrom("Enemy");

        Rigidbody2D magicBulletRb = magicBullet.GetComponent<Rigidbody2D>();

        magicBulletRb.velocity = shotDirection * bulletSpeed;
    }
}
