using System.Collections;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [Header("Balance")]
    [SerializeField] private float damage;
    [SerializeField] private float timeAlive;

    [Header("Supporting")]
    [SerializeField] private string damagableTag;
    [SerializeField] private LayerMask bulletLayer;
    [SerializeField] private GameObject explosion;

    private string _from;


    private void Start()
    {
        StartCoroutine(IEDestroy());
    }

    private void SpawnExplosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }

    private IEnumerator IEDestroy()
    {
        yield return new WaitForSeconds(timeAlive);
        BulletDestroy();
    }

    public void BulletDestroy()
    {
        SpawnExplosion();
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer(_from))
            return;

        if (collision.tag == damagableTag && !collision.isTrigger)
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
        
        if (bulletLayer.Contains(collision.gameObject.layer))
        {
            if (_from == collision.gameObject.GetComponent<Bullet>().GetFrom())
                return;
        }

        if (collision.tag != "Undestroyable" && !collision.isTrigger)
        {
            BulletDestroy();
        }
    }

    public void SetFrom(string from)
    {
        _from = from;
    }

    public string GetFrom()
    {
        return _from;
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
