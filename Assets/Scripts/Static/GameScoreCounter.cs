using System;
using UnityEngine;

public class GameScoreCounter : MonoBehaviour
{
    private static int _gameScore = 0;

    public static event Action<int> OnGameScoreChanged;

    public static void IncreaseCount(int addScore)
    {
        _gameScore += addScore;
        OnGameScoreChanged?.Invoke(_gameScore);
    }

    public static int GetGameScoreCounter()
    {
        return _gameScore;
    }

    public static void ScoreReset() 
    {
        _gameScore = 0;
    }
}
