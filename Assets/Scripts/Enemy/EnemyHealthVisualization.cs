using UnityEngine.UI;
using UnityEngine;


[DisallowMultipleComponent]

public class EnemyHealthVisualization : MonoBehaviour
{
    [SerializeField] private Health enemyHealth;
    [SerializeField] private GameObject hpBarGameObject;
    [SerializeField] private Image hpBarImage;
    [SerializeField] private EnemyPatrol enemyPatrol;
    [SerializeField] private EnemyNearChasing enemyChasing;

    private void OnEnable()
    {
        enemyHealth.OnHealthChanged += HPBarValueChanger;
    }

    private void OnDisable()
    {
        enemyHealth.OnHealthChanged -= HPBarValueChanger;
    }
     
    private void HPBarValueChanger(float damage, float maxHp, float currentHp)
    {
        
        if (currentHp != maxHp && !hpBarGameObject.activeInHierarchy)
        
            hpBarGameObject.SetActive(true);
        hpBarImage.fillAmount = (float)currentHp / maxHp;

    }
}
