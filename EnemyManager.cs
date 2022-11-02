using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public float timer = 0f;
    public float temp = 0f;
    // Start is called before the first frame update
    void Start()
    {
        spawnNewEnemy();
        timer = Time.deltaTime;
    }

    private void spawnNewEnemy()
    {
        //Instantiate[]
        Instantiate(enemyPrefab, spawnPoints[0].transform.position, Quaternion.identity);
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer - temp > 5)
        {
            spawnNewEnemy();
            temp = timer;
        }
    }
}
