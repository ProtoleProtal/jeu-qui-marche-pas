using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMilitaire : MonoBehaviour
{
    
    public GameObject survivor,actualSurvivor;
    public Vector3 survivorPoint = Vector3.zero;
    public GameObject ralliement;

    public float speedMove = 2f;

    private void Update()
    {
         if (actualSurvivor != null)
        {

            actualSurvivor.transform.position = Vector3.MoveTowards(actualSurvivor.transform.position, new Vector3(ralliement.transform.position.x, ralliement.transform.position.y, ralliement.transform.position.z), speedMove);

            if (actualSurvivor.transform.position == new Vector3(ralliement.transform.position.x, ralliement.transform.position.y, ralliement.transform.position.z))
                actualSurvivor = null;
        }



    }

     private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger " + gameObject.name + " Stay : " + other.name);

        if (other.CompareTag("Player") && !other.gameObject.GetComponent<ship>().isEmpty)
            {
                if (actualSurvivor == null)
                {
                    actualSurvivor = Instantiate<GameObject>(survivor, new Vector3(gameObject.transform.position.x, ralliement.transform.position.y, gameObject.transform.position.z), Quaternion.identity, gameObject.transform.parent);
                    other.gameObject.GetComponent<ship>().survivor--;
                }

            }
    

    }

}
