using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarelsWorld : World
{

    [SerializeField]
    private RoundManager roundManager;

    public override WorldType Name => WorldType.KarelsWorld;

    public override void CheckState(StateMachine<State<WorldType>, WorldType> stateMachine)
    {

        base.CheckState(stateMachine);
    }

    public override void EnterState(WorldType oldState)
    {
        base.EnterState(oldState);
        roundManager.NextRound();
    }

    public override void LeaveState(WorldType newState)
    {
        base.LeaveState(newState);
    }

    public override void NextState()
    {
        WorldStateMachine.Instance.SetState(WorldType.HumanWorld);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
