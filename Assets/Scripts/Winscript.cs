using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winscript : MonoBehaviour
{


    public GameObject winscreen;
    public static int conditionwin = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //conditionwin = 0;
        winscreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(conditionwin);

        if(conditionwin == 15)
        {
            Debug.Log("win");
            winscreen.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Survivor")
        {
            conditionwin++;
        }
    }
}
