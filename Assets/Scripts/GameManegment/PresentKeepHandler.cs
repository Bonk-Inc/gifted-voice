using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentKeepHandler : MonoBehaviour
{
    [SerializeField]
    private Dictionary<string, Present> presents = new Dictionary<string, Present>();

    public static PresentKeepHandler Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddPresent(string id, Present present)
    {
        if (presents.ContainsKey(id))
            return;

        presents.Add(id, present);
        present.transform.SetParent(transform);
    }

    public Present GetPresent(string id)
    {
        if (!presents.ContainsKey(id))
            return null;

        return presents[id];
    }
    
}
