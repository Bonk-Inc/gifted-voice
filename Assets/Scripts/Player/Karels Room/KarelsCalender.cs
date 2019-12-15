using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarelsCalender : MonoBehaviour
{


    [SerializeField]
    private TMPro.TextMeshProUGUI calenderText;

    private void Start()
    {
        print("last: " + RoundManager.Instance.LastRound + "  Current: " + RoundManager.Instance.CurrentRound);
        calenderText.text = Mathf.Abs(RoundManager.Instance.LastRound - RoundManager.Instance.CurrentRound).ToString();
    }

}
