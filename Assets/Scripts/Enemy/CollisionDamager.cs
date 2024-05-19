using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
public class CollisionDamager : MonoBehaviour
{
    [SerializeField] private string damagableTag;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float damage;
    [SerializeField] private float coldownTime = 2;
    [SerializeField] private EnemyState enemyState;

    private bool canAttack = true;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == damagableTag && !collision.isTrigger && canAttack && layerMask.Contains(collision.gameObject.layer) && (enemyState && enemyState.GetEnemyState() != "Death" || !enemyState))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            canAttack = false;
            StartCoroutine(IECanAttack());
        }
    }



    private IEnumerator IECanAttack()
    {
        yield return new WaitForSeconds(coldownTime);
        canAttack = true;
    }
}
