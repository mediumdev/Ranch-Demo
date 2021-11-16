using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeInOut : MonoBehaviour
{
    CsGlobals gl;

    void Start()
    {
        gl = FindObjectOfType(typeof(CsGlobals)) as CsGlobals;
    }

    public void OnFadeInStart()
    {
        gl.AUDIO_MANAGER.FadeInOut(true);
    }

    public void OnFadeOutStart()
    {
        gl.AUDIO_MANAGER.FadeInOut(false);
    }

    public void OnFadeOutComplete()
    {
        SceneManager.LoadScene("Game");
    }
}
