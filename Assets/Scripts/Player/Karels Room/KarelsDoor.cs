using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarelsDoor : MonoBehaviour
{

    private Collider colly;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colly = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colly = null;
        }
    }


    private void Update()
    {
        if (colly != null && Input.GetKeyDown(KeyCode.Space))
        {
            WorldStateMachine.Instance.NextState();
        }
    }

}
