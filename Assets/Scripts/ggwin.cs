using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ggwib : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("colli");
        if (other.gameObject.layer == 31) 
        {
            Debug.Log(Winscript.conditionwin);
            Winscript.conditionwin ++;
        }
    }
}
