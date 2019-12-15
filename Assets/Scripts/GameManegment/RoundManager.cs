using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{

    [SerializeField]
    private int lastRound = 5;

    private int currentRound = 0;

    public event Action<int> roundChanged;
    public event Action lastRoundOver;

    public static RoundManager Instance { get; private set; }

    public int LastRound => lastRound;

    public bool RoundsOver { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public void NextRound()
    {
        currentRound++;

        roundChanged?.Invoke(currentRound);

        if (currentRound > lastRound)
        {
            lastRoundOver?.Invoke();
            RoundsOver = true;
        }
    }

    public void SetLastRound(int lastRound)
    {
        this.lastRound = lastRound;
    }

}
