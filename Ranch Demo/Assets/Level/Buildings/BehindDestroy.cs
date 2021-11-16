using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehindDestroy : MonoBehaviour
{
    CsGlobals gl;

    void Awake()
    {
        gl = FindObjectOfType(typeof(CsGlobals)) as CsGlobals;
    }

    void Update()
    {
        if (!gl.IS_RESTARTING)
        {
            if (transform.position.z < gl.TRACTOR.transform.position.z - gl.BEHIND_DISTANCE)
            {
                Destroy(gameObject);
            }
        }
    }
}
