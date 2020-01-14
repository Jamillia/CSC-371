using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 50f;
    public float jumpHeight = 5f;
    public float maxVelocity = 10f;
    public float friction = 10f;
    Rigidbody rb;
    bool isgrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (isgrounded)
        {
            if (getVelSq(rb.velocity) <= maxVelocity * maxVelocity)
            {
                rb.AddRelativeForce((Vector3.right * x + Vector3.forward * z) * speed);
            } else
            {
                rb.AddRelativeForce(-rb.velocity);
            }

            if (x == 0 && rb.velocity.x != 0)
            {
                rb.AddRelativeForce(new Vector3(-friction * rb.velocity.x, 0, 0));
            }
            if (z == 0 && rb.velocity.z != 0)
            {
                rb.AddRelativeForce(new Vector3(0, 0, -friction * rb.velocity.z));
            }

            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity += Vector3.up * jumpHeight;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isgrounded = false;
        }
    }

    private float getVelSq(Vector3 velocity)
    {
        return new Vector3(velocity.x, 0, velocity.z).sqrMagnitude;
    }
}
