using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    private List<BoostType> currentBoosts = new List<BoostType>();
    private List<BoostType> usedBoosts = new List<BoostType>();

    public static BoostManager Instance { get; private set; }

    public event Action<BoostType> BooostRegistered;

    private void Awake()
    {
        
        if (Instance != null) {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void RegisterBoost(BoostType boost)
    {
        if (currentBoosts.Contains(boost) || usedBoosts.Contains(boost))
            return;

        currentBoosts.Add(boost);
        BooostRegistered?.Invoke(boost);
    }

    public void UseBoost(BoostType boost)
    {
        if (!currentBoosts.Contains(boost))
            return;

        currentBoosts.Remove(boost);
        usedBoosts.Add(boost);
    }

    public void CheckBoosts(Func<BoostType ,bool> use)
    {
        for (int i = 0; i < currentBoosts.Count; i++)
        {
            bool used = use.Invoke(currentBoosts[i]);
            if (used)
                UseBoost(currentBoosts[i]);
        }
    }

    public bool ContainsBoost(BoostType type, bool checkUsed)
    {
        return currentBoosts.Contains(type) || (checkUsed && usedBoosts.Contains(type));
    }
}
