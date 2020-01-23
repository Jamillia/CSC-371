using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{

    float topBound = 30f;
    float lowBound = -10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < lowBound)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
    }
}
