using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public GameObject player;
    public float speed = 5f;
    public float detectionRange = 10f;
    public float attackZone = 2f;
    private bool playerInRange = false;
    private bool playerInAttackZone = false;
    public float gravity = -18f;
    public Vector3 randMove;
    public float timer = 0f;
    public float timeTemp = 0f;
    public float temp, playerDist;
   // public delegate void enemyKilled();
    //public static event enemyKilled OnEnemyKilled;


    public float health = 20f;




    void Start()
    {
        timer = Time.deltaTime;
        player = FindObjectOfType<player>().gameObject;
    }

    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Cease();
        }
    }

    void Cease()
    {
        Destroy(gameObject);
    }

    void CheckRange()
    {
        //playerDist = Vector3.Distance(transform.position, player.transform.position);
        playerDist = Vector3.Distance(transform.position, player.transform.position);

        if (playerDist < attackZone)
        {
            playerInAttackZone = true;
            playerInRange = true;
        }
        else if (playerDist < detectionRange)
        {
            playerInAttackZone = false;
            playerInRange = true;
        }
        else
        {
            playerInAttackZone = false;
            playerInRange = false;
        }
        
        //if (!playerInRange) {
        //    //Debug.Log("Reach rand");
        //    randMove.x = transform.position.x + UnityEngine.Random.Range(-50, 50);
        //    randMove.z = transform.position.z + UnityEngine.Random.Range(-50, 50);
        //    //Debug.Log(transform.position);
        //}
    }

    void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //transform.rotation = Vector3.RotateTowards(transform.position, player.transform.position, speed * Time.deltaTime, 0.0f);

        Vector3 newDirection = Vector3.RotateTowards(transform.position, player.transform.position, speed * Time.deltaTime, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);
        //temp = Vector3.Distance(transform.position, player.transform.position);
        //if (temp < 2f)
        //{
        //    playerInAttackZone = true;
        //}
    }
    //void OnTriggerEnter(Collider targetObj)
    //{
    //    if (targetObj.gameObject.tag == "Player" || transform.position == player.transform.position)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        CheckRange();
        
        if (timer - temp > 5)
        {
            if (!playerInRange)
            {
                //Debug.Log("Reach rand");
                randMove.x = transform.position.x + UnityEngine.Random.Range(-50, 50);
                randMove.z = transform.position.z + UnityEngine.Random.Range(-50, 50);
                //Debug.Log(transform.position);
            }
            temp = timer;
        }
        if (playerInRange && !playerInAttackZone)
        {
            ChasePlayer();
        }
        else if (playerInRange && playerInAttackZone)
        {
            //bug it
            
            Destroy(this.gameObject);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, randMove, speed * Time.deltaTime);
        }
        
    }
}
