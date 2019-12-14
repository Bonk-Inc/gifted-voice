using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private TMPro.TextMeshProUGUI timerText;

    private void Start() {
        timer.OnTimeUpdated += UpdateTimerText;
        timer.StartTimer();
    }

    private void UpdateTimerText(float timeLeft) {
        int wholeSecondsLeft = Mathf.FloorToInt(timeLeft);
        timerText.SetText(wholeSecondsLeft.ToString());
    }
}
