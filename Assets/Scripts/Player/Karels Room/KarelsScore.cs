using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarelsScore : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText;

    void Start()
    {
        if (PresentKeepHandler.Instance == null)
        {
            scoreText.SetText("0");
            return;
        }
        scoreText.SetText(PresentKeepHandler.Instance.transform.childCount.ToString());
    }

}
