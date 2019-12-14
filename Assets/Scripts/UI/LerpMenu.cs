using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMenu : MonoBehaviour
{
    private int menu;

    [SerializeField]
    private float screenSize;

    [SerializeField]
    private float lerpSpeed;

    private Coroutine lerpRoutine;

    public void LerpTo(int menu)
    {
        this.menu = menu;

        if (lerpRoutine != null)
            StopCoroutine(lerpRoutine);

        lerpRoutine = StartCoroutine(LerpToMenu());
    }

    private IEnumerator LerpToMenu()
    {
        var rTransform = (RectTransform)this.transform;
        var currentOffset = rTransform.offsetMin.x;
        var desired = menu * screenSize;
        while (Mathf.Abs(currentOffset-desired) > 0.05f)
        {
            currentOffset = Mathf.Lerp(currentOffset, desired, lerpSpeed * Time.deltaTime);
            rTransform.offsetMin = new Vector2(currentOffset, rTransform.offsetMin.y);
            rTransform.offsetMax = new Vector2(currentOffset, rTransform.offsetMax.y);
            yield return null;
        }
        currentOffset = desired;
        rTransform.offsetMin = new Vector2(currentOffset, rTransform.offsetMin.y);
        rTransform.offsetMax = new Vector2(currentOffset, rTransform.offsetMax.y);

    }


}
