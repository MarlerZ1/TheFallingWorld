using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]
public class EnemyStateChanger : MonoBehaviour
{
    [SerializeField] private float timeToChasingAfterPlayerHide;
    [SerializeField] private EnemyState enemyState;
    [SerializeField] private EnemyPatrol enemyPatrol;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StopAllCoroutines();
            if (enemyState.GetEnemyState() != "Death")
                enemyState.EnemyChasing();
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StopAllCoroutines();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if (enemyState.GetEnemyState() != "Death")
                StartCoroutine(IEStopChasing());
        }
    }

    private IEnumerator IEStopChasing()
    {
        yield return new WaitForSeconds(timeToChasingAfterPlayerHide);
        if (enemyState.GetEnemyState() != "Death")
            StartCoroutine(enemyPatrol.IEPlayIdleAnimation());
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}


