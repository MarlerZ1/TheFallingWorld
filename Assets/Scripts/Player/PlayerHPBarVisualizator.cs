using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[DisallowMultipleComponent]
[RequireComponent(typeof(Image))]
public class PlayerHPBarVisualizator : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject wasted;
    [SerializeField] private float timeToOpenLoseScene;

    private Health _playerHealth;
    private Image _hpBar;
    private void Awake()
    {
        _playerHealth = player.GetComponent<Health>();
        _hpBar = GetComponent<Image>();
    }

    private void HpBarValueChanger(float damage, float maxHp, float currentHp)
    {
        _hpBar.fillAmount = (float)currentHp / maxHp;
        if (currentHp <= 0)
        {
            wasted.SetActive(true);
            StartCoroutine(IEOpenLoseScene());
        }
    }

    private IEnumerator IEOpenLoseScene()
    {
        yield return new WaitForSeconds(timeToOpenLoseScene);
        SceneManager.LoadScene(3);
    }

    private void OnEnable()
    {
        _playerHealth.OnHealthChanged += HpBarValueChanger;
    }

    private void OnDisable()
    {
        _playerHealth.OnHealthChanged -= HpBarValueChanger;
    }
}
