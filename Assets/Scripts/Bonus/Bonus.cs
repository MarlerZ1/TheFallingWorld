using UnityEngine;

[DisallowMultipleComponent]
public class Bonus : MonoBehaviour
{
    [SerializeField] private int addScore;
    [SerializeField] private LayerMask playerLayermask;

    [SerializeField] private GameObject bonusSounds;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerLayermask.Contains(collision.gameObject.layer))
        {
            if (bonusSounds)
                Instantiate(bonusSounds, transform.position, Quaternion.identity);

            GameScoreCounter.IncreaseCount(addScore);
            Destroy(gameObject);
        }
    }
}
