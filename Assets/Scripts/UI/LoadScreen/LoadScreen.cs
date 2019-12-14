using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LoadScreen : MonoBehaviour {


    public abstract void OpenLoadscreen(Action onLoadscreenOpen = null);

    public abstract void CloseLoadscreen(Action onLoadscreenClose = null);

}
