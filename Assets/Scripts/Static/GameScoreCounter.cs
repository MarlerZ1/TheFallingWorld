using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreCounter : MonoBehaviour
{
    private static int _gameScore = 0;

    public static event Action<int> OnGameScoreChanged;

    public static void IncreaseCount(int addScore)
    {
        _gameScore += addScore;
        OnGameScoreChanged?.Invoke(_gameScore);
        print("GetGameScoreCounter\t" + _gameScore);
    }

    public static int GetGameScoreCounter()
    {
        print("GetGameScoreCounter\t" + _gameScore);
        return _gameScore;
    }
}
