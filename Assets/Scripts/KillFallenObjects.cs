using UnityEngine;


[DisallowMultipleComponent]
[RequireComponent(typeof(Collider2D))]
public class KillFallenObjects : MonoBehaviour
{
    [SerializeField] private string damagableTag;
    [SerializeField] private LayerMask excludedLayers;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (excludedLayers.Contains(collision.gameObject.layer))
            return;

        if (collision.tag == damagableTag)
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(int.MaxValue);
        }
        else
        {
            Destroy(collision.gameObject);
        }
    }
}
