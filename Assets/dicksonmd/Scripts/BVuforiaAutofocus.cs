using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class BVuforiaAutofocus : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        VuforiaBehaviour.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        VuforiaBehaviour.Instance.RegisterOnPauseCallback(OnPaused);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnVuforiaStarted()
    {
        refocus();
    }

    private void OnPaused(bool isPaused)
    {
        if (!isPaused)
        {
            refocus();
        }
    }

    void refocus()
    {
        bool focusModeSet = CameraDevice.Instance.SetFocusMode(
        CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);

        if (!focusModeSet)
        {
            Debug.Log("Failed to set focus mode (unsupported mode).");
        }
        else
        {
            Debug.Log("focus mode updated");
        }
    }
}
