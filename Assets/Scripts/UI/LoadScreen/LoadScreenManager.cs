using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenManager : MonoBehaviour
{
    [SerializeField]
    private LoadScreen loadscreen;

    public static LoadScreenManager Instance { get; private set; }

    private Queue<Func<bool>> conditions = new Queue<Func<bool>>();
    private Coroutine loadingRoutine;


    private void Awake() {

        if (Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadUntil(Func<bool> condition, Action loadScreenOpen = null) {
        AddLoadCondition(condition);
        StartLoading(loadScreenOpen);
    }

    public void StartLoading(Action loadScreenOpen = null)
    {
        loadscreen.OpenLoadscreen(loadScreenOpen);

        if (loadingRoutine != null)
            StopCoroutine(loadingRoutine);

        loadingRoutine = StartCoroutine(Load(StopLoading));
    }

    public void AddLoadCondition(Func<bool> condition)
    {
        conditions.Enqueue(condition);
    }

    public void StopLoading()
    {
        if (loadingRoutine != null)
            StopCoroutine(loadingRoutine);

        loadscreen.CloseLoadscreen();
    }

    private IEnumerator Load(Action onLoadComplete)
    {
        while (conditions.Count > 0)
        {
            var condition = conditions.Dequeue();
            while (condition != null && !condition.Invoke())
                yield return null;
        }
        onLoadComplete?.Invoke();
    }

}
