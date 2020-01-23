using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedKill : MonoBehaviour
{
    public float speed_to_kill;
    private Rigidbody2D rb;
    public float pushbackForce = 500.0f;
    public float yForceLimiter;
    public float yMagLimiter = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    public float magnitude(Vector3 a)
    {
        return Mathf.Sqrt(Mathf.Pow(a.x, 2)
            + Mathf.Pow(a.y / yMagLimiter, 2));
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            //print("Veloctity kill meter: " + rb.velocity);
            print("Magnitude kill meter: " + magnitude(rb.velocity));
            if (magnitude(rb.velocity) >= speed_to_kill)
            {
                col.gameObject.GetComponent<Enemy>().health = 0;
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / yForceLimiter);
                rb.AddForce(rb.velocity * -pushbackForce);
            }
        }
    }
}
