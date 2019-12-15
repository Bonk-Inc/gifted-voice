using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    bool won;

    [SerializeField]
    private TMPro.TextMeshProUGUI text;

    [SerializeField]
    private string winTextm = "OwO You did it!! good job!!", loseText = ":( sad";

    void Start()
    {
        won = WorldStateMachine.Instance.Won;
        text.text = won ? winTextm : loseText;
        GameEnder.Instance.EndGame();   
    }

    public void Restart()
    {
        SceneLoader.Instance.LoadScene(WorldType.KarelsWorld.ToString());
    }
}
