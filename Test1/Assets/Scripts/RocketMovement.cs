using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float rocketLifeTime = 10f;
    public float rocketSpeed = 35f;
    public float explosionRadius = 2.7f;
    public float explosionPower = 10f;
    GameObject moveTo;
    Rigidbody rb;

    private void Start()
    {
        moveTo = GameObject.FindWithTag("GoTo");
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, rocketLifeTime);
        rb.velocity = rocketSpeed * (moveTo.transform.position - transform.position).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
            foreach (Collider hit in Physics.OverlapSphere(transform.position, explosionRadius))
            {
                if (hit.CompareTag("Player"))
                {
                    Rigidbody hitrb = hit.GetComponentInParent<Rigidbody>();
                    hitrb.AddExplosionForce(explosionPower, transform.position, explosionRadius,
                        1f, ForceMode.Impulse);
                }
            }
        }
    }
}
