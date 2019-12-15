using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleDisplay : MonoBehaviour
{
    [SerializeField]
    private BoostType type;

    private void Start()
    {
        gameObject.SetActive(BoostManager.Instance.ContainsBoost(type, true));
    }

}
