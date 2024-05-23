using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Menu))]
public class Portal : MonoBehaviour
{
    [Header("If player Collision waiting")]
    [SerializeField] private bool waitPlayerCollision;

    [Header("If just exists")]
    [SerializeField, Range(0, 120)] private float existsTime;

    [Header("Objects")]
    [SerializeField] private LayerMask nextLvlActivateLayerMask;
    [SerializeField] private Animator animator;

    private void Start()
    {
        animator.SetBool("isIdle", true);

        if (!waitPlayerCollision)
            StartCoroutine(IEWaitForClouse());
    }



    private IEnumerator IEWaitForClouse()
    {
        yield return new WaitForSeconds(existsTime);
        animator.SetBool("isIdle", false);
    }

    public void DestroyGameObject()
    {
        if (waitPlayerCollision)
            SceneManager.LoadScene(2);
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (waitPlayerCollision && nextLvlActivateLayerMask.Contains(collision.gameObject.layer))
        {
            collision.gameObject.SetActive(false);
            animator.SetBool("isIdle", false);
        }
    }
}
