using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    public float rotate_speed = 5f;
    public GameObject bullet;
    public GameObject player;
    public GameObject bullet_point;
    public float x_offset;
    public float y_offset;
    float sqrt;

    public bool has_shot = false;
    public bool can_shoot = true;
    public float fireRate = 3f;
    float temp_fireRate;

    public PlayerMove move_script;

    // Start is called before the first frame update
    void Start()
    {
        temp_fireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {
        //Mouse Aiming

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotate_speed * Time.deltaTime);
        if (Input.GetMouseButton(0) && can_shoot)
        {
            Instantiate(bullet, bullet_point.transform.position, Quaternion.identity);
            can_shoot = false;
            has_shot = true;
        }


        if (has_shot)
        {
            move_script.did_shot = true;
            has_shot = false;
        }
        if (can_shoot == false)
        {
            fireRate -= Time.deltaTime;
        }
        if (fireRate <= 0)
        {
            fireRate = temp_fireRate;
            can_shoot = true;
        }

        //Follow the Player
        transform.position = new Vector2(player.transform.position.x + x_offset, player.transform.position.y + y_offset);
    }

    public float distance(GameObject a, GameObject b)
    {
        sqrt = (Mathf.Pow(a.transform.position.x - b.transform.position.x, 2)
            + Mathf.Pow(a.transform.position.y - b.transform.position.y, 2));
        return Mathf.Sqrt(sqrt);
    }

    
}
