﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    private LoadScreenManager loadScreen;

    private void Start()
    {
        loadScreen = LoadScreenManager.Instance;
    }

    public void LoadScene(string sceneName)
    {
        var operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;
        loadScreen.LoadUntil(() => {
            TimerSingleton.Instance.OnTimerFinished.AddListener(WorldStateMachine.Instance.CurrentState.NextState);
            return operation.progress == 1;
        }, () => {
            operation.allowSceneActivation = true;
        });
    }


}
