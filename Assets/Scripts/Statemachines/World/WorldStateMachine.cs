using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldStateMachine : StateMachine<World, WorldType>
{
    [SerializeField]
    private World[] worldStates;

    private void Start()
    {
        for (int i = 0; i < worldStates.Length; i++)
        {
            AddState(worldStates[i].Name, worldStates[i]);
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

    public void SetStateToHuman()
    {
        SetState(WorldType.HumanWorld);
    }
}
