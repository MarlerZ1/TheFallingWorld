using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Health))]
public class DeathBonus : MonoBehaviour
{
    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _health.OnDeath += IncreasePlayerScore;
    }

    private void IncreasePlayerScore(bool authoDestroy)
    {
        GameScoreCounter.IncreaseCount(1);
    }

}
