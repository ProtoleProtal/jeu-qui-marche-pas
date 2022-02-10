using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsForce : MonoBehaviour
{
    Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //rb.AddForce(PointAndShoot.crosshairs.transform.position * 500);
        rb.AddForce(transform.forward * 500);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
