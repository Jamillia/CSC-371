using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnContact : MonoBehaviour
{
    public float explosionRadius = 2.7f;
    public float explosionPower = 10f;
    public ParticleSystem explosion;
    public AudioClip explosionSound;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        explosion.Play();
        audioSource.PlayOneShot(explosionSound);
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Wall"))
        {
            foreach (Collider hit in Physics.OverlapSphere(transform.position, explosionRadius))
            {
                if (hit.CompareTag("Player"))
                {
                    Rigidbody hitrb = hit.GetComponentInParent<Rigidbody>();
                    hitrb.AddExplosionForce(explosionPower, transform.position, explosionRadius,
                        1f, ForceMode.Impulse);
                }
            }
            Destroy(gameObject);
        }
    }
}
