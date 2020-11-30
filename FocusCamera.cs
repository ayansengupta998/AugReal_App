using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FocusCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool focusModeSet = CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        if (!focusModeSet)
        {
            Debug.Log("Failed to set the focus mode to continusauto (unsupported mode).");
        }
    }

}