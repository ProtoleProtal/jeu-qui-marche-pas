using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Rigidbody rigidbody;

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

    // Update is called once per frame
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
    }

    private void Movement()
    {
        float moveAmount = movespeed * Time.deltaTime;
        this.rigidbody.useGravity = true;

        if (moveUp)
        {
            transform.Translate(new Vector3(0, moveAmount, 0));
            this.rigidbody.useGravity = false;
        }
        else if (moveDown)
        {
            transform.Translate(new Vector3(0, -moveAmount, 0));
        }

        if (moveLeft && !isGround)
        {
            transform.Translate(new Vector3(-moveAmount, 0, 0));

            helicoAnimator.SetBool("Right", false);
            helicoAnimator.SetBool("Left", true);
        }

        if (moveRight && !isGround)
        {
            transform.Translate(new Vector3(moveAmount, 0, 0));

            helicoAnimator.SetBool("Left", false);
            helicoAnimator.SetBool("Right", true);
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
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Trigger " + gameObject.name + " Exit : " + other.name);

        if (other.CompareTag("Ground"))
            isGround = false;

    }

    private void Forward() => model.transform.rotation = new Quaternion(5, 0,0, -20);

    private void Left() => model.transform.rotation = new Quaternion(0, 100, 0, 90);

    private void Right() => model.transform.rotation = new Quaternion(0, 100, 0, -90);

}