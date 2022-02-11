using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{

    public GameObject projectile;
    public Transform player;

    public float speed;
    public float stoppingDistancce;
    public float retreatDistance;

    private float timeBTWShots;
    public float startTimeBTWShots;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBTWShots = startTimeBTWShots;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > stoppingDistancce)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        else if (Vector3.Distance(transform.position, player.position) < stoppingDistancce && Vector3.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }

        else if (Vector3.Distance(transform.position, player.position) < retreatDistance) 
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBTWShots <=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBTWShots = startTimeBTWShots;
        }

        else 
        {
            timeBTWShots -= Time.deltaTime;
        }
    }
}