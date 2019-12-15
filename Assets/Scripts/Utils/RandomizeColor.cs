using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeColor : MonoBehaviour
{
    [SerializeField]
    private Renderer objectRenderer;
    MaterialPropertyBlock propBlock;

    private void Start()
    {
        propBlock = new MaterialPropertyBlock();
        for (int i = 0; i < objectRenderer.materials.Length; i++)
        {
            ChangeColor(i);
        }
    }

    private void ChangeColor(int materialIndex)
    {
        Color newColor = Random.ColorHSV(0, 1);

        objectRenderer.GetPropertyBlock(propBlock);
        propBlock.SetColor("_Color", newColor);

        objectRenderer.SetPropertyBlock(propBlock, materialIndex);
    }
}
