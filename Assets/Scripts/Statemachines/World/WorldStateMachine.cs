using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateMachine : StateMachine<World, WorldType>
{
    [SerializeField]
    private SceneLoader sceneloader;

    [SerializeField]
    private World[] worldStates;

    private static WorldStateMachine instance = null;

    public static WorldStateMachine Instance { get => instance; }

    private bool stateSets = false;

    private void Awake()
    {
        if (WorldStateMachine.instance && WorldStateMachine.instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        TimerSingleton.Instance.OnTimerFinished.AddListener(NextState);
        if (stateSets) return;
        for (int i = 0; i < worldStates.Length; i++)
        {
            stateSets = true;
            AddState(worldStates[i].Name, worldStates[i]);
            worldStates[i].SceneLoader = sceneloader;
        }
    }

    public override void AddState(WorldType name, World state)
    {
        base.AddState(name, state);
    }

    public override void SetState(WorldType newState)
    {
        base.SetState(newState);
    }

    public void NextState()
    {
        CurrentState.NextState();
    }
}
