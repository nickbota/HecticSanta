using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance { get; private set; }

    //Events
    public event Action OnGameStart;
    public void GameStart()
    {
        if (OnGameStart != null) OnGameStart();
    }
    public event Action OnGameOver;
    public void GameOver()
    {
        if (OnGameOver != null) OnGameOver();
    }

    private void Awake()
    {
        instance = this;
    }
}