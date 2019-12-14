using UnityEngine;

public abstract class World : State<WorldType>{

    [SerializeField]
    private SceneLoader sceneLoader;

    public override void LeaveState(WorldType newState)
    {
        base.LeaveState(newState);
        sceneLoader.LoadScene(newState.ToString());
    }
}