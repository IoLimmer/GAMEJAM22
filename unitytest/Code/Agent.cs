using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public GameObject player;
    public float detectionRange = 5f;
    public float speed = 5f;
    public float attackZone = 1f;
    private bool playerInRange = false;
    private bool playerInAttackZone = false;

    public float temp;

    // Start is called before the first frame update
    void Start()
    {
    }

    void CheckRange()
    {
        
    }

    void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        temp = Vector3.Distance(transform.position, player.transform.position);
        if (temp < 2f)
        {
            playerInAttackZone = true;
        }
    }
    void OnTriggerEnter(Collider targetObj)
    {
        if (targetObj.gameObject.tag == "Player" || transform.position == player.transform.position)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckRange();
        if (playerInRange && playerInAttackZone == false)
        {
            ChasePlayer();
        }
        else if(playerInRange && playerInAttackZone)
        {
            //bug it
            Destroy(this.gameObject);
        }
    }
}
