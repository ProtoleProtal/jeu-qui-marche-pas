using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public GameObject[] survivor;

    public float speedMove = 2f;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Trigger " + gameObject.name + " Stay : " + other.name);

        if (survivor.Length > 0)
        {
            if (other.CompareTag("Player") && !other.gameObject.GetComponent<ship>().isFull)
            {
                for (int i = 0; i < survivor.Length; i++)
                {
                    if (survivor[i] != null)
                    survivor[i].transform.position = Vector3.MoveTowards(survivor[i].transform.position, new Vector3(other.transform.position.x, survivor[i].transform.position.y, other.transform.position.z), speedMove);
                }
            } 
        }
    }

}
