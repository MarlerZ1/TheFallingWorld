using System;
using UnityEngine;


[DisallowMultipleComponent]
public class Health : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] private bool authoDestroy;

    [SerializeField] private GameObject destroyedParent;

    public event Action<float, float, float> OnHealthChanged;
    public event Action<bool> OnDeath;


    private float _curHealth;
    private bool _isAlive = true;

    private void Awake()
    {
        _curHealth = MaxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (!_isAlive)
            return;

        _curHealth -= damage;

        OnHealthChanged?.Invoke(damage, MaxHealth, _curHealth);

        if (_curHealth <= 0)
        {
            _curHealth = 0;
            _isAlive = false;
            OnDeath?.Invoke(authoDestroy);

            if (authoDestroy)
                DestroyObject();
        }
    }

    public void Healing(float heal)
    {
        _curHealth += heal;
        if (_curHealth > MaxHealth)
            _curHealth = MaxHealth;
        OnHealthChanged?.Invoke(0, MaxHealth, _curHealth);
    }


    public void DestroyObject()
    {
        if (!destroyedParent)
            Destroy(gameObject);
        else
            Destroy(destroyedParent);
    }
}
