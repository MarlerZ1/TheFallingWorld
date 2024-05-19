using UnityEngine;
[DisallowMultipleComponent]

public class EnemyParentDestroy : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private HealhAudioHandler healthAudioHandler;


    private void OnEnable()
    {
        health.OnDeath += AuthoDestroyObject;
        healthAudioHandler.OnParentDestroy += DestroyObject;
    }

    private void OnDisable()
    {
        health.OnDeath -= AuthoDestroyObject;
        healthAudioHandler.OnParentDestroy -= DestroyObject;
    }


    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void AuthoDestroyObject(bool authoDestroy)
    {
        if (authoDestroy)
            Destroy(gameObject);
    }
}
