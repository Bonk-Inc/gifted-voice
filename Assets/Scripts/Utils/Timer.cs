using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float startTime = 60;

    private Coroutine countDownRoutine;

    public float TimeLeft { get; private set; }
    public float StartTime { get => startTime; }

    public event Action<float> OnTimeUpdated;
    public UnityEvent OnTimerFinished;

    public void StartTimer() {
        ResetTimer();
        ResumeTimer();
    }

    public void ResetTimer() {
        TimeLeft = StartTime;
    }

    public void ResumeTimer() {
        countDownRoutine = StartCoroutine(CountDown());
    }

    public void StopTimer() {
        StopCoroutine(countDownRoutine);
    }

    private IEnumerator CountDown() {

        while(TimeLeft > 0) {
            yield return null;
            UpdateTimeLeft();
        }
        OnTimerFinished.Invoke();
    }

    private void UpdateTimeLeft()
    {
        TimeLeft -= Time.deltaTime * Time.timeScale;
        TimeLeft = TimeLeft < 0 ? 0 : TimeLeft;
        OnTimeUpdated?.Invoke(TimeLeft);
    }

}
