using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    public static GameEnder instance;

    public static GameEnder Instance
    {
        get
        {
            if (instance == null)
                instance = CreateEnder();

            return instance;
        }
    }

    public event Action OnEndGame;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void EndGame()
    {
        OnEndGame?.Invoke();
        OnEndGame = null;
    }

    public static GameEnder CreateEnder()
    {
        var gobj = new GameObject();
        var gameEnder = gobj.AddComponent<GameEnder>();
        return gameEnder;
    }

    public static GameEnder GetInstance(bool spawnNew)
    {
        if (!spawnNew)
            return instance;

        return Instance;
        
    }
}
