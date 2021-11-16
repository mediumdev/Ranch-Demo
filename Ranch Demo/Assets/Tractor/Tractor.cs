using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tractor : MonoBehaviour
{
    CsGlobals gl;
    AudioManager audioManager;

    GUIManager gui_manager;

    public GameObject wheelFrontRight;
    public GameObject wheelFrontLeft;
    public GameObject wheelFrontRightBase;
    public GameObject wheelFrontLeftBase;
    public GameObject wheelBackRight;
    public GameObject wheelBackLeft;
    public Animator animator;

    public float maxMoveSpeed;
    float newMoveSpeed;

    float speed = 0f;
    float speedRotate = 0f;

    bool mouseIsDown = false;
    bool clickRight = false;
    bool clickLeft = false;

    int levelCount = 0;

    Rigidbody rb;

    float currentSlowMotionAmount = 0f;

    void Awake()
    {
        gl = FindObjectOfType(typeof(CsGlobals)) as CsGlobals;
        audioManager = FindObjectOfType(typeof(AudioManager)) as AudioManager;

        gui_manager = gl.GUI_MANAGER.GetComponent<GUIManager>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Camera.main.transform.rotation = Quaternion.Euler(62.5f, 0, 0);
        Camera.main.transform.position = new Vector3(0, 30, transform.position.z - 25f);

        gl.HEALTH = gl.MAX_HEALTH;

        gui_manager.UpdateLevel();
        gui_manager.UpdateHealth();
        gui_manager.UpdateChickenCount();

        newMoveSpeed = maxMoveSpeed;

        gl.AUDIO_MANAGER.TractorEnginePlay();
        gl.AUDIO_MANAGER.RaceAmbientPlay();
    }

    void Update()
    {
        if (!gl.IS_RESTARTING)
        {
            Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y, transform.position.z - 7f);
        

            if (speed < maxMoveSpeed)
            {
                speed += 0.5f;
            }

            if (((Input.GetKey(KeyCode.D) == true) || (clickRight)) && (transform.position.x < gl.TRACK_WIDTH / 2))
            {
                speedRotate = maxMoveSpeed / 2f;
            }
            else if (((Input.GetKey(KeyCode.A) == true) || (clickLeft)) && (transform.position.x > 0 - gl.TRACK_WIDTH / 2))
            {
                speedRotate = 0 - maxMoveSpeed / 2f;
            }
            else
            {
                speedRotate = 0f;
            }

            if (Input.GetMouseButtonDown(0))
            {
                mouseIsDown = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                mouseIsDown = false;
                clickRight = false;
                clickLeft = false;
            }

            if (mouseIsDown)
            {
                Vector3 mousePos = Input.mousePosition;
                if (mousePos.x >= Screen.width / 2)
                {
                    clickRight = true;
                    clickLeft = false;
                }
                else
                {
                    clickLeft = true;
                    clickRight = false;
                }
            }

            if (gl.HEALTH <= 0)
            {
                gl.AUDIO_MANAGER.TractorFailPlay();
                Restart();
            }

            if (newMoveSpeed > maxMoveSpeed)
            {
                maxMoveSpeed += gl.ACCELERATE;
            }
            else
            {
                maxMoveSpeed = newMoveSpeed;
            }
        }
        else
        {
            if (speed > 0f)
            {
                speed -= speed / 50f;
            }
            else
            {
                speed = 0f;
            }

            if (speedRotate > 1f)
            {
                speedRotate -= speedRotate / 50f;
            }
            else if(speedRotate < -1f)
            {
                speedRotate += Mathf.Abs(speedRotate / 50f);
            }
            else
            {
                speedRotate = 0f;
            }
        }

        if (gl.SLOWMOTION)
        {
            Time.timeScale = gl.SLOWMOTION_VALUE;
            audioManager.SetMasterPitch(gl.SLOWMOTION_VALUE);
            currentSlowMotionAmount += Time.deltaTime;
            if (currentSlowMotionAmount > gl.SLOWMOTION_AMOUNT)
            {
                currentSlowMotionAmount = 0f;
                gl.SLOWMOTION = false;
            }
        }
        else
        {
            Time.timeScale = 1.0f;
            audioManager.SetMasterPitch(1.0f);
        }

        float rotationSpeed = speed / 2;
        float rotationY = speedRotate * 2;
        wheelFrontRight.transform.Rotate(rotationSpeed, 0, 0);
        wheelFrontRightBase.transform.rotation = Quaternion.Euler(0, rotationY, 0);
        wheelFrontLeft.transform.Rotate(rotationSpeed, 0, 0);
        wheelFrontLeftBase.transform.rotation = Quaternion.Euler(0, rotationY, 0);
        wheelBackRight.transform.Rotate(rotationSpeed, 0, 0);
        wheelBackLeft.transform.Rotate(rotationSpeed, 0, 0);
    }

    public void Restart()
    {
        gl.IS_RESTARTING = true;
        animator.SetTrigger("Fade");
    }

    void FixedUpdate()
    {
        rb.rotation = Quaternion.Euler(0, speedRotate, 0);
        rb.velocity = new Vector3(speedRotate, rb.velocity.y, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!gl.IS_RESTARTING)
        {
            if (collision.gameObject.tag == "Sheep")
            {
                gl.SHEEP_COUNT++;
                gui_manager.UpdateChickenCount();
                levelCount++;
                if (levelCount >= gl.SHEEP_NUM_NEXT_LEVEL)
                {
                    gl.AUDIO_MANAGER.NextSpeedPlay();
                    levelCount = 0;
                    gl.LEVEL++;
                    gui_manager.UpdateLevel();
                    gui_manager.UpdateChickenCount();
                    gl.HEALTH = gl.MAX_HEALTH;
                    gui_manager.UpdateHealth();
                    newMoveSpeed += gl.ADD_SPEED;
                }
                Destroy(collision.gameObject);
            }

            if (collision.gameObject.tag == "Health")
            {
                if (gl.HEALTH < gl.MAX_HEALTH)
                {
                    gl.AUDIO_MANAGER.HealthPlay();
                    gl.HEALTH += gl.HEALTH_UP;
                    if (gl.HEALTH > gl.MAX_HEALTH)
                    {
                        gl.HEALTH = gl.MAX_HEALTH;
                    }
                    gui_manager.UpdateHealth();
                    Destroy(collision.gameObject);
                }
            }

            if (collision.gameObject.tag == "SlowMotion")
            {
                currentSlowMotionAmount = 0f;
                gl.SLOWMOTION = true;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                Destroy(collision.gameObject);
            }
        }
    }
}
