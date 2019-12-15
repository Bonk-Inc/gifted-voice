using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldStateMachine : StateMachine<World, WorldType>
{
    private bool stateSets = false;
    [SerializeField]
    private SceneLoader sceneloader;

    [SerializeField]
    private World[] worldStates;

    private static WorldStateMachine instance = null;

    public static WorldStateMachine Instance { get => instance; }

    public int currentFloor;

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
        SceneManager.activeSceneChanged += (scene1, scene2) =>
        {
            TimerSingleton.Instance?.OnTimerFinished.AddListener(NextState);
        };
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

    [ContextMenu("Next State")]
    public void NextState()
    {
        CurrentState.NextState();
    }
}
