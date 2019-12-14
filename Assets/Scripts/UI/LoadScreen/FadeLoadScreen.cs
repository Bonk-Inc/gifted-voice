using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeLoadScreen : LoadScreen
{
    [SerializeField]
    private Image loadImage;

    [SerializeField]
    private float lerpPrecision = 0.05f, lerpSpeed = 10;

    private Coroutine alphaChangeRoutine;
    
    
    public override void CloseLoadscreen(Action onLoadscreenClose = null)
    {
        onLoadscreenClose += () => loadImage.raycastTarget = false;
        ChangeAlphaTo(0, onLoadscreenClose);
    }

    public override void OpenLoadscreen(Action onLoadscreenOpen = null)
    {
        loadImage.raycastTarget= true;
        ChangeAlphaTo(1, onLoadscreenOpen);
    }

    private void ChangeAlphaTo(float newAlpha, Action onFinish)
    {
        if (alphaChangeRoutine != null)
            StopCoroutine(alphaChangeRoutine);

        alphaChangeRoutine = StartCoroutine(LerpImageAlpheTo(newAlpha, onFinish));
    }

    private IEnumerator LerpImageAlpheTo(float newAlpha, Action onFinish)
    {
        
        Color imageColor = loadImage.color;
        while (Mathf.Abs(imageColor.a - newAlpha) > lerpPrecision)
        {
            yield return null;
            imageColor.a = Mathf.Lerp(imageColor.a, newAlpha, lerpSpeed * Time.deltaTime);
            loadImage.color = imageColor;
        }
        onFinish?.Invoke();
    }
}
