using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    CsGlobals gl;

    public Transform build;
    public AudioClip breacking;
    bool breacking_enable = true;

    GUIManager gui_manager;

    private void Awake()
    {
        gl = FindObjectOfType(typeof(CsGlobals)) as CsGlobals;

        gui_manager = gl.GUI_MANAGER.GetComponent<GUIManager>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Building")
        {
            Destroy(gameObject);
        }

        if ((collision.gameObject.tag == "Tractor") || (collision.gameObject.tag == "FlyPlank"))
        {
            if (breacking_enable)
            {
                breacking_enable = false;
                gl.AUDIO_MANAGER.PlayOneShot(breacking);
            }
            if ((gl) && (collision.gameObject.tag == "Tractor"))
            {
                gl.HEALTH -= gl.DAMAGE;
                if (gl.HEALTH < 0)
                {
                    gl.HEALTH = 0;
                }
                gui_manager.UpdateHealth();
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.GetComponent<Rigidbody>().detectCollisions = false;
            }

            foreach (Transform child in build)
            {
                Rigidbody rb = child.gameObject.GetComponent<Rigidbody>();
                rb.useGravity = true;
                rb.constraints = RigidbodyConstraints.None;
                child.tag = "FlyPlank";
                child.gameObject.layer = 9;
            }
        }
    }
}
