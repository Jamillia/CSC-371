using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed = 20f;
    public float turnSpeed = 50f;

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxis("Horizontal") * turnSpeed;
        Vector3 movez = Input.GetAxis("Vertical") * Vector3.forward * moveSpeed;
        transform.Rotate(Vector3.up, movex * Time.deltaTime);
        transform.Translate(movez * Time.deltaTime);
    }
}
