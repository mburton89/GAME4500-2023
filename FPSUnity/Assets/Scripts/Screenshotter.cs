using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshotter : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            string screenshotFileName = "Screenshot_" + PlayerPrefs.GetInt("screenshotIndex") + ".PNG";
            print(screenshotFileName + " Captured");
            ScreenCapture.CaptureScreenshot(screenshotFileName);
            PlayerPrefs.SetInt("screenshotIndex", PlayerPrefs.GetInt("screenshotIndex") + 1);
        }
    }
}