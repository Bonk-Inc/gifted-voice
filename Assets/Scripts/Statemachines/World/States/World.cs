using UnityEngine;

public abstract class World : State<WorldType>{

    protected TimerSingleton timer;
    private SceneLoader sceneLoader;

    public SceneLoader SceneLoader { get => sceneLoader; set => sceneLoader = value; }

    public override void EnterState(WorldType oldState)
    {
        timer = TimerSingleton.Instance;
        base.EnterState(oldState);
    }

    public override void LeaveState(WorldType newState)
    {
        base.LeaveState(newState);
        SceneLoader.LoadScene(newState.ToString());
    }
}