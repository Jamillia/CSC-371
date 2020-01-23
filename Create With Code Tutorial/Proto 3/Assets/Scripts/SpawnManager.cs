using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject obstaclePrefab;
    Vector3 spawnPos = new Vector3(25, 0, 0);
    float startDelay = 2;
    float repeatRate = 2;
    PlayerController pcScript;

    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("spawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnObstacle()
    {
        if (!pcScript.gameOver)
        {
            Instantiate(obstaclePrefab,
                spawnPos,
                obstaclePrefab.transform.rotation);
        }
    }
}
