using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    private void Update()
    {
        if (spawnInterval > 0)
        {
            spawnInterval -= Time.deltaTime;
        }

        if (spawnInterval <= 0)
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            int index = Random.Range(0, ballPrefabs.Length);
            Instantiate(ballPrefabs[index],
                spawnPos,
                ballPrefabs[index].transform.rotation);
            spawnInterval = Random.Range(3, 5);
        }
    }
}
