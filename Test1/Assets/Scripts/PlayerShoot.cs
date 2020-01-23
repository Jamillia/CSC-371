using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject rocket;
    public GameObject cam;
    public GameObject spawnpt;
    public AudioClip shootSound;
    AudioSource audioSource;
    public float attackSpeed = 0.8f;
    float attackInterval;
    bool canAttack;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        attackInterval = 0f;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canAttack)
        {
            attackInterval += Time.deltaTime;
        }
        if (attackInterval >= attackSpeed)
        {
            canAttack = true;
            attackInterval = 0f;
        }
        if (Input.GetMouseButton(0) && canAttack)
        {
            Instantiate(rocket,
                spawnpt.transform.position,
                Quaternion.Euler(
                    -cam.transform.rotation.eulerAngles.x,
                    cam.transform.rotation.eulerAngles.y + 180f,
                    cam.transform.rotation.eulerAngles.z
                ));
            audioSource.PlayOneShot(shootSound, 0.1f);
            canAttack = false;
        }
    }
}
