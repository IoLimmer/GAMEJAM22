using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int deathCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        //deathCounter = 0;
    }

    public void IncrementDeathCounter()
    {
        deathCounter += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (deathCounter >= 4)
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }
    }
}
