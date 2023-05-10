using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private bool _gameOver = false;

    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public void setGameOver(bool gameOver)
    {
        _gameOver = gameOver;
    }
    public bool getGameOver()
    {
        return _gameOver;
    }
}
