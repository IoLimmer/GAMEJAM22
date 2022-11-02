using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Rigidbody rbody;
    public Vector3 agentPos;
    public float step;


    public Vector3 WP;
    bool walkPointSet;
    public float walkPointRange = 10f;

    public float sightRange = 100000f, attackRange = 0f;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("FPP").transform;
        agentPos = transform.position;
        rbody = GetComponent<Rigidbody>();
        step = 100 * Time.deltaTime;
    }

    private void FindWP()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        WP = new Vector3(transform.position.x + randomX, transform.position.z + randomZ);
        if(Physics.Raycast(WP, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void patrol()
    {
        if (!walkPointSet)
        {
            FindWP();
        }

        if (walkPointSet){
            transform.position = Vector3.MoveTowards(transform.position, WP, step);
        }
        Vector3 distanceToWP = transform.position - WP;

        if(distanceToWP.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void Chase()
    {

      transform.position = Vector3.MoveTowards(transform.position, player.position, step);
    }

    private void attack()
    {
        //enemy stop moving
        transform.position = Vector3.MoveTowards(transform.position, WP, step);

        //Attack code here
        randBug();
        Destroy(this);
    }

    public void randBug()
    {
        Debug.Log(Random.Range(1, 6));
    }

    // Start is called before the first frame update
    void Start()
    {
        Awake();
    }

    // Update is called once per frame
    void Update()
    {
        step = 100 * Time.deltaTime;
        agentPos = transform.position;
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) 
        {
            patrol();
         }
        if(playerInSightRange && !playerInAttackRange)
        {
            Chase();
        }
        if(playerInAttackRange && playerInSightRange)
        {
            attack();
        }

    }
}
