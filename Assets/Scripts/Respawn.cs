using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnpoint;

    void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("scene fajr dev");
        //player.transform.position = respawnpoint.transform.position;
    }
}