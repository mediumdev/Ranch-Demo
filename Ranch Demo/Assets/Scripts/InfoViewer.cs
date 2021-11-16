using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoViewer : MonoBehaviour
{
    private int FramesPerSec;
    private float frequency = 1.0f;
    private string fps;

    GUIStyle guiStyle;

    void Start()
    {
        guiStyle = new GUIStyle();

        StartCoroutine(FPS());
    }

    private IEnumerator FPS()
    {
        for (; ; )
        {
            int lastFrameCount = Time.frameCount;
            float lastTime = Time.realtimeSinceStartup;
            yield return new WaitForSeconds(frequency);
            float timeSpan = Time.realtimeSinceStartup - lastTime;
            int frameCount = Time.frameCount - lastFrameCount;

            fps = string.Format("FPS: {0}", Mathf.RoundToInt(frameCount / timeSpan));
        }
    }


    void OnGUI()
    {
        guiStyle.fontSize = 20;
        GUI.Label(new Rect(Screen.width - 200, 100, 150, 20), fps, guiStyle);
    }
}
