using UnityEngine;


[DisallowMultipleComponent]
public class GameScoreResetter : MonoBehaviour
{
    private void Awake()
    {
        GameScoreCounter.ScoreReset();
    }
}
