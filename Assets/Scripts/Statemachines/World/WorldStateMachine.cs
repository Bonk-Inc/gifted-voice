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

    private void Awake()
    {
        if (WorldStateMachine.instance)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        for (int i = 0; i < worldStates.Length; i++)
        {
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
