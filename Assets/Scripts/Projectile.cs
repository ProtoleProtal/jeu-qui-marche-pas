using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    
    public float speed;

    private Transform player;
    private Vector3 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y)
        {
           DestroyProjectile();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        int pv = 0;
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
        }

        if(other.gameObject.layer == 21)
        {
            Debug.Log(pv);
            pv +=1;
            if(pv == 3)
            {
                Debug.Log(pv);
                SceneManager.LoadScene("scene fajr dev");
            }
            
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}