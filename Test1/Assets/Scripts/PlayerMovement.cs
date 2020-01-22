using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float groundSpeed = 10f;
    public float airSpeed = 1f;
    private float airSpeedMultiplier = 1f;
    public float jumpHeight = 5f;
    public float maxVelocity = 10f;
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
        Vector3 move = x * transform.right + z * transform.forward;
        bool jump = Input.GetButtonDown("Jump");
        if (isgrounded)
        {
            rb.velocity = move * groundSpeed + rb.velocity.y * transform.up;
            if (jump)
            {
                rb.velocity += transform.up * jumpHeight;
            }
        }
        else
        {
            if (Mathf.Abs((move * airSpeed * airSpeedMultiplier +
                transform.right * rb.velocity.x + transform.forward * rb.velocity.z).magnitude)
                <= maxVelocity)
            {
                rb.velocity += move * airSpeed * airSpeedMultiplier;
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
}
