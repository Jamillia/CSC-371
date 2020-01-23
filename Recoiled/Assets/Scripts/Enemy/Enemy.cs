using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 3f;
    public float sightRadius = 5f;
    public GameObject weapon;
    //public int EnemyId;
    public float rotate_weapon_speed = 5f;
    public GameObject player;
    public bool haveTurned;
    public Vector2 weaponOffset;
    public bool willMove;
    public float speed;
    public float tempSpeed;

    public GameObject bullet;
    public GameObject bullet_point;
    public float fireRate = 3f;
    float tempFireRate;

    private Rigidbody2D rb;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        tempSpeed = speed;
        //weapon = GameObject.Find("Weapon" + "_" + EnemyId);
        tempFireRate = fireRate;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (willMove)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }
        if (haveTurned)
        {
            Vector3 theScale = weapon.transform.localScale;
            theScale.x *= -1;
            weapon.transform.localScale = theScale;
            haveTurned = false;
        }

        weapon.transform.position = new Vector2(transform.position.x + weaponOffset.x, transform.position.y + weaponOffset.y);
        
        if (player != null)
        {
            
            if (weapon.transform.localScale.x < 0)
            {
                direction = weapon.transform.position - player.transform.position;
            }
            else
            {
                direction = player.transform.position - weapon.transform.position;
            }
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            weapon.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotate_weapon_speed * Time.deltaTime);

            fireRate -= Time.deltaTime;
            if (fireRate <= 0)
            {
                Instantiate(bullet, bullet_point.transform.position, Quaternion.identity);
                fireRate = tempFireRate;
            }
        }
        
        if (health <= 0)
        {
            print("Enemy Killed; health 0");
            Destroy(weapon);
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            health -= 1;
            print("Hit Enemy");
            //Destroy(col.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = col.gameObject;
            speed = 0;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player = null;
            Vector3 direction = new Vector3(0, 0, 0);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            weapon.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotate_weapon_speed * Time.deltaTime);
            speed = tempSpeed;
        }
    }
}
