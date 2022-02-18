using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puteputeputesalope : MonoBehaviour
{

    public GameObject encule;
    public static int conditionwin = 0;


    // Start is called before the first frame update
    void Start()
    {
        encule.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Survivor")
        {
            conditionwin++;
        }
    }
}