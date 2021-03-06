using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ship : MonoBehaviour
{


    //public GameObject helico;
    //public GameObject prefabBullet;
    //public GameObject canonPos;



    [Header("MOVEMENT")]
    public float movespeed = 3;
    public Vector2 move;
    public bool moveUp, moveDown;
    public bool moveLeft, moveRight;
    public bool dashInput;
    public bool isDashing;
    public Rigidbody rigidbody;

    [SerializeField]
    private float _dashDelay = 5f;


    [Header("COLLIDER")]
    public bool isGround;

    [Header("ANIMATION")]
    public Animator helicoAnimator;
    public GameObject model;

    [Header("SURVIVOR")]
    public int survivor, survivorMax = 5;
    public bool isFull = false;
    public bool isEmpty = true;
    public bool isChargeSurvivor = false;

    public GameObject prefabBullet;
    public Transform canonPos;

    float dashingTime = 0;
    void ChangeDashing() 
    {
        if (isDashing)
        {
            //isDashing = false;
        }
        else
        {
            isDashing = true;
            dashingTime = 0;
        }
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(prefabBullet, new Vector3(canonPos.transform.position.x, canonPos.transform.position.y, canonPos.transform.position.z), Quaternion.identity);
        }
    }

    void FixedUpdate()
    {

        if (survivor >= survivorMax)
            isFull = true;
        else
            isFull = false;

        if (survivor <= 0)
            isEmpty = true;
        else
            isEmpty = false;

        /*if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject bullet = Instantiate(prefabBullet, new Vector3( canonPos.transform.position.x, canonPos.transform.position.y, canonPos.transform.position.z), Quaternion.identity);
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            helico.transform.Rotate(-20, 0, 0);
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            helico.transform.Rotate(20, 0, 0);
        }*/

        InputManager();

        Movement();

        this.rigidbody.velocity = new Vector3(0, -5, 0);


    }

    private void InputManager()
    {
        moveUp = Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.UpArrow);
        moveDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        moveLeft = Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow);
        moveRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);
        dashInput = Input.GetKey(KeyCode.LeftShift);


    }

    private void Movement()
    {
        int dashValue = 3;
        bool dashOnCooldown = false;

        float moveAmount = movespeed * Time.deltaTime;
        this.rigidbody.useGravity = true;

        if (dashInput)
        {
            ChangeDashing();
        }

        if (dashingTime < 0.5)
            dashingTime += Time.deltaTime;
        else
            isDashing = false;


        if (moveUp)
        {
            if(isDashing)
            {
                transform.Translate(new Vector3(0, moveAmount * dashValue, 0));
            }
            else 
            {
                transform.Translate(new Vector3(0, moveAmount, 0));
                this.rigidbody.useGravity = false;
            }
            
        }
        else if (moveDown)
        {
            if (isDashing)
            {
                transform.Translate(new Vector3(0, -moveAmount * dashValue, 0));
            }
            else 
            {
                transform.Translate(new Vector3(0, -moveAmount, 0));
            }
        }

        if(!isGround)
        {
            if (moveLeft)
            {
                if (isDashing)
                {
                    transform.Translate(new Vector3(-moveAmount * dashValue, 0, 0));
                }

                else 
                {
                    transform.Translate(new Vector3(-moveAmount, 0, 0));
                }

                helicoAnimator.SetBool("Right", false);
                helicoAnimator.SetBool("Left", true);
            }

            if (moveRight)
            {

                if (isDashing)
                {
                    transform.Translate(new Vector3(moveAmount * dashValue, 0, 0));
                }
                else {
                    transform.Translate(new Vector3(moveAmount, 0, 0));
                }

                helicoAnimator.SetBool("Left", false);
                helicoAnimator.SetBool("Right", true);
            }
        }
        
        if (isGround)
        {
            helicoAnimator.SetBool("Left", false);
            helicoAnimator.SetBool("Right", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger " + gameObject.name + " Enter : " + other.name);

        if (other.CompareTag("Ground"))
            isGround = true;

        if (other.CompareTag("Charge"))
            isChargeSurvivor = true;
        else if (other.CompareTag("DeCharge"))
            isChargeSurvivor = false;

        if (isChargeSurvivor == true)
        {
            if (other.gameObject.CompareTag("Survivor") && !isFull)
            {
                survivor++;
                Destroy(other.gameObject);
            }
        }

        if (other.CompareTag("Ground") || other.gameObject.layer == 26)
        {
            SceneManager.LoadScene("scene fajr dev");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger " + gameObject.name + " Exit : " + other.name);

        if (other.CompareTag("Ground"))
            isGround = false;

    }

    private void Forward() => model.transform.rotation = new Quaternion(5, 0, 0, -20);

    private void Left() => model.transform.rotation = new Quaternion(0, 100, 0, 90);

    private void Right() => model.transform.rotation = new Quaternion(0, 100, 0, -90);

}