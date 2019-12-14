using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonWorld : World
{
    [SerializeField]
    private float startTime;

    public override WorldType Name => WorldType.DemonWorld;

    public override void CheckState(StateMachine<State<WorldType>, WorldType> stateMachine)
    {
        base.CheckState(stateMachine);

    }

    public override void EnterState(WorldType oldState)
    {
        base.EnterState(oldState);
    }

    public override void LeaveState(WorldType newState)
    {
        base.LeaveState(newState);
    }

    public override void NextState()
    {
        WorldStateMachine.Instance.SetState(WorldType.KarelsWorld);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
