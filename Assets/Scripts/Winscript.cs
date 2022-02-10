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
        winscreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(conditionwin == 15)
        {
            winscreen.SetActive(true);
        }
    }
}
