using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GUIManager : MonoBehaviour
{
    CsGlobals gl;

    public GameObject level;
    public GameObject health;
    public GameObject chickenCount;

    void Awake()
    {
        gl = FindObjectOfType(typeof(CsGlobals)) as CsGlobals;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void UpdateLevel()
    {
        level.GetComponent<TextMeshProUGUI>().text = "Lvl. " + gl.LEVEL.ToString();
    }

    public void UpdateHealth()
    {
        health.GetComponent<TextMeshProUGUI>().text = gl.HEALTH.ToString() +  "%";
    }

    public void UpdateChickenCount()
    {
        chickenCount.GetComponent<TextMeshProUGUI>().text = gl.SHEEP_COUNT.ToString() + "/" + (gl.LEVEL * gl.SHEEP_NUM_NEXT_LEVEL).ToString();
    }
}
