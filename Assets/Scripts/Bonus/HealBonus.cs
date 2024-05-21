using UnityEngine;

[DisallowMultipleComponent]
public class HealBonus : MonoBehaviour
{
    [SerializeField] private int addHealth;
    [SerializeField] private LayerMask playerLayermask;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerLayermask.Contains(collision.gameObject.layer))
        {
            collision.gameObject.GetComponent<Health>().Healing(addHealth);
            Destroy(gameObject);
        }
    }
}
