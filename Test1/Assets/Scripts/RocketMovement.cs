using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float rocketLifeTime = 10f;
    public float rocketSpeed = 30f;
    GameObject moveTo;
    Rigidbody rb;

    private void Start()
    {
        moveTo = GameObject.FindWithTag("GoTo");
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, rocketLifeTime);
        rb.velocity = rocketSpeed * (moveTo.transform.position - transform.position).normalized;
    }
}
