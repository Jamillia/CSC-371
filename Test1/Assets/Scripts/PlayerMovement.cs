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
    public float stepInterval = 0.48f;
    public AudioClip[] footSteps;
    AudioSource audioSource;
    Rigidbody rb;
    bool isgrounded;
    float footSoundInterval = 0;
    int footSoundIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = x * transform.right + z * transform.forward;
        bool jump = Input.GetButtonDown("Jump");
        if (footSoundInterval > 0)
        {
            footSoundInterval -= Time.deltaTime;
        }
        if (isgrounded)
        {
            rb.velocity = move * groundSpeed + rb.velocity.y * transform.up;
            if ((x != 0 || z != 0) && footSoundInterval <= 0)
            {
                audioSource.PlayOneShot(footSteps[footSoundIndex]);
                footSoundInterval = stepInterval;
                footSoundIndex = (footSoundIndex + 1) % footSteps.Length;
            }
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
