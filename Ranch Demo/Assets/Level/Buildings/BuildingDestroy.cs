using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingDestroy : MonoBehaviour
{
    void Update()
    {
        if (transform.childCount <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
