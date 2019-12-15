using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraRoundBoost : MonoBehaviour
{

    [SerializeField]
    private RoundManager round;

    [SerializeField]
    private BoostManager boostManager;

    private void Start()
    {
        boostManager.BooostRegistered += (type) =>
        {
            if (type != BoostType.extraRound)
                return;

            round.SetLastRound(round.LastRound + 1);
            boostManager.UseBoost(type);
        };
    }

}
