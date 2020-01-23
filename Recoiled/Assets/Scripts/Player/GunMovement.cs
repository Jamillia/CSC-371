using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour
{
    Vector3 theScale;
    Vector3 tempScale;
    public PlayerMove move_script;

    // Start is called before the first frame update
    void Start()
    {
        tempScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (move_script.isFacingRight)
        {
            theScale = transform.localScale;
            theScale.y = tempScale.y;
            transform.localScale = theScale;
        }
        else
        {
            theScale = transform.localScale;
            theScale.y = -tempScale.y;
            transform.localScale = theScale;
        }
    }
}
