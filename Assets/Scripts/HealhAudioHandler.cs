using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class HealhAudioHandler : MonoBehaviour
{
    public event Action OnParentDestroy;

    [SerializeField] private GameObject damageSound;
    [SerializeField] private GameObject healingSound;
    [SerializeField] private GameObject deathSound;

    [SerializeField] private float timeToDeath;
    [SerializeField] private bool DestroyByAnimation;
    
    private AudioSource _audioSource;
    private Health _health;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _health = GetComponent<Health>();
    }

    private void OnEnable()
    {
        _health.OnHealthChanged += PlayHealthChangeSound;
        _health.OnDeath += PlayDeathSound;
    }

    private void OnDisable()
    {
        _health.OnHealthChanged -= PlayHealthChangeSound;
        _health.OnDeath -= PlayDeathSound;
    }

    private void PlayHealthChangeSound(float damage, float maxHealth, float curHealth)
    {
        if (curHealth > 0 && damage > 0)
            Instantiate(damageSound, transform.position, Quaternion.identity);
        else if (damage <= 0)
            Instantiate(healingSound, transform.position, Quaternion.identity);
    }

    private void PlayDeathSound(bool authoDestroy)
    {
        if (!authoDestroy && !DestroyByAnimation)
        {
            Instantiate(deathSound, transform.position, Quaternion.identity);
            StartCoroutine(IEDestroyAfterSoundsPlay());
        } 
    }

    private IEnumerator IEDestroyAfterSoundsPlay()
    {
        yield return new WaitForSeconds(timeToDeath);
        OnParentDestroy?.Invoke();
    }
}
