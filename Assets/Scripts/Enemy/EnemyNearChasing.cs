using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]

public class EnemyNearChasing : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    private Rigidbody2D _rb;


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (player == null)
            return;

        float velY = _rb.velocity.y;
        _rb.velocity = new Vector2(player.transform.position.x - transform.position.x, 0).normalized * speed;
        _rb.velocity += new Vector2(0, velY);

      
        bool rotationFlag = _rb.velocity.x > 0;

        transform.rotation = Quaternion.Euler(0, rotationFlag ? 0 : 180, 0);
    }
}
