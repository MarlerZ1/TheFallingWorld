using TMPro;
using UnityEngine;
[DisallowMultipleComponent]
[RequireComponent(typeof(Menu))]
public class LvlEndsMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private Menu _menu;
    private void Start()
    {
        _menu = GetComponent<Menu>();
    }

    private void ActivateLvlEndScreen()
    {
        _menu.ChangePauseState();
        text.text = GameScoreCounter.GetGameScoreCounter().ToString();
    }
}
