using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDestroy : MonoBehaviour
{
    CsGlobals gl;
    void Awake()
    {
        gl = FindObjectOfType(typeof(CsGlobals)) as CsGlobals;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tractorPosZ = gl.TRACTOR.transform.position.z;
        if (!gl.IS_RESTARTING)
        {
            if (transform.position.z + gl.GROUND_SIZE + gl.BEHIND_DISTANCE < tractorPosZ)
            {
                Destroy(gameObject);
            }
        }
    }
}
