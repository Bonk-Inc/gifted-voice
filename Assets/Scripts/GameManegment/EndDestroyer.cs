using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDestroyer : MonoBehaviour
{
    void Awake()
    {
        GameEnder.Instance.OnEndGame += DestroyThis;
    }

    private void OnDestroy()
    {
        GameEnder ge = GameEnder.GetInstance(false);
        if (ge != null)
            ge.OnEndGame -= DestroyThis;
    }

    private void DestroyThis()
    {
        Destroy(this.gameObject);
    }


}
