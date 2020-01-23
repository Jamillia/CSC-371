using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public int MaxHealth;
    public GameObject[] healthPoints;
    public PlayerMove move;
    public WeaponAim aim;
    private bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        move = player.GetComponent<PlayerMove>();
        GameObject weapon = GameObject.Find("Weapon");
        aim = weapon.GetComponent<WeaponAim>();
        MaxHealth = health;

        for (int i = 0; i < health; i++)
        {
            healthPoints[i] = GameObject.Find("Health" + (i+1));
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > MaxHealth)
        {
            health = MaxHealth;
        }

        if (health == 3)
        {
            healthPoints[0].SetActive(true);
            healthPoints[1].SetActive(true);
            healthPoints[2].SetActive(true);
        }
        else if (health == 2)
        {
            healthPoints[0].SetActive(true);
            healthPoints[1].SetActive(true);
            healthPoints[2].SetActive(false);
        }
        else if (health == 1)
        {
            healthPoints[0].SetActive(true);
            healthPoints[1].SetActive(false);
            healthPoints[2].SetActive(false);
        }

        if (health <= 0)
        {
            move.canMove = false;
            aim.can_shoot = false;
            healthPoints[0].SetActive(false);
            healthPoints[1].SetActive(false);
            healthPoints[2].SetActive(false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy_Bullet")
        {
            health--;
        }
    }

}
