using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    public float throwSpeed = 0.5f;
    float throwInterval = 0;
    // Update is called once per frame
    void Update()
    {
        if (throwInterval < throwSpeed)
        {
            throwInterval += Time.deltaTime;
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && throwInterval >= throwSpeed)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            throwInterval = 0;
        }
    }
}
