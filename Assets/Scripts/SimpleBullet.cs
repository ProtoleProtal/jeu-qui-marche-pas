using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class SimpleBullet : MonoBehaviour
{
    public bool right = true;
    public bool left = false;
    Rigidbody rb;
    [SerializeField] float timeRemaining = 3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if(left)
        {
            rb.AddForce(-1 * 10, 0, 0, ForceMode.Impulse);
        }
        if (right)
        {
            rb.AddForce(1 * 10, 0, 0, ForceMode.Impulse);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            right = true;
            left = false;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            right = false;
            left = true;
        }

        if (right)
        {
            rb.AddForce(1 * 20, 0, 0, ForceMode.Impulse);
        }

        else if (left)
        {
            rb.AddForce(-1 * 20, 0, 0, ForceMode.Impulse);
        }
      
        AutoDestruct();
    }
    void OnTriggerEnter(Collider co)
    {
        Destroy(gameObject);
    }
    void OnTriggerExit(Collider co)
    {
        Destroy(gameObject);
    }

    void AutoDestruct()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}