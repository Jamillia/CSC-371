using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ledge : MonoBehaviour
{
    BoxCollider2D boxCollider;
    public bool isTouchingPlayer;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        isTouchingPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s") && isTouchingPlayer)
        {
            boxCollider.enabled = false;
        }
        

        if (Input.GetKeyUp("s"))
        {
            boxCollider.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isTouchingPlayer = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            isTouchingPlayer = false;
        }
    }
}
