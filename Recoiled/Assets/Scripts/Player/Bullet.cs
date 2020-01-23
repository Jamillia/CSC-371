using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life_time;
    public float speed;
    Vector2 moveDirection_1;
    Vector2 moveDirection_2;
    public bool shootme = false;

    private Rigidbody2D rb;
    public float lifeTime = 5f;
    public GameObject shotParticle;
    public GameObject particle1;
    private GameObject particle2;

    public float sqrt;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(shotParticle, transform.position, Quaternion.identity);

        moveDirection_1 = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position); //When Im not shooting myself
        moveDirection_2 = (transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition));
        moveDirection_1.Normalize();
        moveDirection_2.Normalize();
        shootme = false;
        rb = GetComponent<Rigidbody2D>();
        particle2 = Instantiate(particle1, transform.position, Quaternion.identity);

        if (distance(GameObject.FindWithTag("Player"), GameObject.FindWithTag("BulletPoint")) > (Mathf.Sqrt(Mathf.Pow(GameObject.FindWithTag("Player").transform.position.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 2)
            + Mathf.Pow(GameObject.FindWithTag("Player").transform.position.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 2))))
        {
            shootme = true;
        }

        if (shootme)
        {
            rb.velocity = new Vector2(moveDirection_2.x * speed * Time.deltaTime,
                moveDirection_2.y * speed * Time.deltaTime);
            shootme = false;
        }
        else
        {
            rb.velocity = new Vector2(moveDirection_1.x * speed * Time.deltaTime,
                moveDirection_1.y * speed * Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (particle2 != null)
        {
            particle2.transform.position = transform.position;
        }

        life_time -= Time.deltaTime * 100;
        if (life_time <= 0)
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
        sqrt = (Mathf.Pow(a.transform.position.x - b.transform.position.x, 2)
            + Mathf.Pow(a.transform.position.y - b.transform.position.y, 2));
        return Mathf.Sqrt(sqrt);
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
