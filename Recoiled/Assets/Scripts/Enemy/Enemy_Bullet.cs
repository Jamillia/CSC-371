using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bullet : MonoBehaviour
{
    public GameObject player;
    public Vector2 startpoint;
    private Rigidbody2D rb;
    public float speed;
    public float lifeTime = 5f;
    public GameObject particle1;
    private GameObject particle2;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        startpoint = transform.position;
        rb.velocity = new Vector2(startpoint.x - player.transform.position.x, startpoint.y - player.transform.position.y) * (speed / distance(gameObject, player));
        particle2 = Instantiate(particle1, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (particle2 != null)
        {
            particle2.transform.position = transform.position;
        }

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            if (particle2 != null)
            {
                Destroy(particle2.gameObject, 60f * Time.deltaTime);
            }
            Destroy(gameObject);
        }
    }

    public float distance(GameObject a, GameObject b)
    {
        return Mathf.Sqrt(Mathf.Pow(a.transform.position.x - b.transform.position.x, 2)
            + Mathf.Pow(a.transform.position.y - b.transform.position.y, 2));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (particle2 != null)
        {
            Destroy(particle2.gameObject, 60f * Time.deltaTime);
        }
        Destroy(gameObject);
    }
}
