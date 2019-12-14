using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletementCounter : Completable
{

    [SerializeField]
    private Completable[] completables;

    public int CompletablesAmount => completables.Length;
    public bool AllCompleted => completables.Length == CountCompleted();

    public int CountCompleted()
    {
        int completed = 0;
        for (int i = 0; i < completables.Length; i++)
            completed += completables[i].IsCompleted() ? 1 : 0;
        return completed;
    }

    public override bool IsCompleted()
    {
        return AllCompleted;
    }
}
