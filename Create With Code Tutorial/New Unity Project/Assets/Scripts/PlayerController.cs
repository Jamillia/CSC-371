using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float horizInput;
    public float speed = 10f;
    public float xRange = 20f;
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis("Horizontal");
        if (transform.position.x < -xRange || transform.position.x > xRange)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xRange, xRange),
                transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.right * horizInput * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab,
                transform.position,
                projectilePrefab.transform.rotation);
        }
    }
}
