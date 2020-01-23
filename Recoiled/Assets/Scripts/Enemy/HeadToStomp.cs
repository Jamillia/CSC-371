using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadToStomp : MonoBehaviour
{
    public float forceMeter = 5.0f;
    public Enemy enemy;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "FeetPos")
        {
            //print("Jump from enemy");
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity =
                new Vector2(GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().velocity.x, 0);
            GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>().AddForce(Vector2.up * forceMeter);
            enemy.health = 0;
        }
        if (col.gameObject.tag == "Platform")
        {
            enemy.speed *= -1;
            enemy.tempSpeed *= -1;
            Vector3 theScale = enemy.transform.localScale;
            theScale.x *= -1;
            enemy.transform.localScale = theScale;
            enemy.haveTurned = true;
        }
    }
}
