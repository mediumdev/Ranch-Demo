using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sheep : MonoBehaviour
{
    CsGlobals gl;

    public float distance;

    Rigidbody rb;

    bool runaway = false;

    float runawayDeg;
    bool rot = false;
    float angle = 0f;
    float degY = 0f;
    bool forceGravity = true;

    void Start()
    {
        gl = FindObjectOfType(typeof(CsGlobals)) as CsGlobals;

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, gl.TRACTOR.transform.position);

        if ((distance < gl.BEHIND_DISTANCE) && (!runaway))
        {
            gl.AUDIO_MANAGER.SheepPlayRandom();
            runaway = true;
            degY = transform.rotation.eulerAngles.y;
            angle = transform.rotation.eulerAngles.y;
        }

        if (runaway)
        {
            if (!rot)
            {
                rot = true;
                runawayDeg = degY + Random.Range(-100f, 100f);
            }
            else
            {
                if (runawayDeg > transform.rotation.y)
                {
                    angle += 0.5f;
                    if (angle > runawayDeg)
                    {
                        rot = false;
                    }
                }
                else
                {
                    angle -= 0.5f;
                    if (angle < runawayDeg)
                    {
                        rot = false;
                    }
                }

                rb.transform.rotation = Quaternion.Euler(0, angle, 0);
            }
        }

        if ((distance > gl.DELETE_DISTANCE) || (transform.position.y < -1f))
        {
            Destroy(gameObject);
        }
    }

    void Spawn()
    {

    }

    void FixedUpdate()
    {
        if (runaway)
        {
            rb.AddRelativeForce(new Vector3(0, 0, gl.SHEEP_SPEED), ForceMode.Force);
        }
        else
        {
            if (forceGravity)
            {
                rb.AddForce(new Vector3(0, -500f, 0), ForceMode.Force);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        forceGravity = false;
    }
}
