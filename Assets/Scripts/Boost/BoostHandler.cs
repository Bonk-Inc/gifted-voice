using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostHandler : MonoBehaviour
{
    [SerializeField]
    private BoostEffect[] boosts;
    private Dictionary<BoostType, BoostEffect> boostsDict;
    private void Awake()
    {
        boostsDict = new Dictionary<BoostType, BoostEffect>();
        for (int i = 0; i < boosts.Length; i++)
        {
            boostsDict.Add(boosts[i].Type, boosts[i]);
        }

        
    }

    private void Start()
    {
        BoostManager.Instance.BooostRegistered += StartBoost;
        BoostManager.Instance.CheckBoosts((boostType) =>
        {
            StartBoost(boostType);
            return false;
        });
    }

    private void StartBoost(BoostType boost)
    {
        if (boostsDict == null || !boostsDict.ContainsKey(boost))
            return;

        boostsDict[boost].Boost();
    }

}
