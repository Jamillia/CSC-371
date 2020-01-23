using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RLFollowPlayer : MonoBehaviour
{

    public GameObject player;
    public Camera cam;
    float xoffset = 0.7f;
    float yoffset = 2.35f;
    float zoffset = 0.8f;
    float flipModel = 180f;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position +
            player.transform.right * xoffset +
            player.transform.forward * zoffset +
            player.transform.up * yoffset;

        transform.rotation =  Quaternion.Euler(-cam.transform.rotation.eulerAngles.x,
            cam.transform.rotation.eulerAngles.y + flipModel,
            cam.transform.rotation.eulerAngles.z);
    }
}
