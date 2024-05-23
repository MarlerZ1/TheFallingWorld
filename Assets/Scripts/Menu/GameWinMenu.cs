using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class GameWinMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Start()
    { 
        ActivateWinScreen();
    }

    private void ActivateWinScreen()
    {
        text.text = GameScoreCounter.GetGameScoreCounter().ToString();
    }
}
