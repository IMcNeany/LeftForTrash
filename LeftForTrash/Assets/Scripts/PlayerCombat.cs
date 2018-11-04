﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    public float max_health = 100;
    public float health = 100;
    public InputManager input;
    public Vector2 player_sprite_offset;
    public Vector2 ranged_aim_pos;
    private Vector2 aim_offset;
    public GameObject Attack_Collider;
    private float new_delay;
    private ObjectPooler OP;
    public bool ranged;

	void Start () {
        input = GetComponent<InputManager>();
        OP = GetComponent<ObjectPooler>();
	}
	
	void Update () {

        Vector2 direction = new Vector2(input.getHorizontal(), input.getVertical());
        
        ranged_aim_pos = new Vector2((transform.position.x - player_sprite_offset.x) + aim_offset.x,
                                     (transform.position.y - player_sprite_offset.y) + aim_offset.y);
        if (direction != Vector2.zero)
        {
            aim_offset = direction;
        }


        if (!ranged)
        {
            if (new_delay > 0.0f)
            {
                new_delay -= 1 * Time.deltaTime;
                Attack_Collider.SetActive(true);
            }
            else
            {
                Attack_Collider.SetActive(false);
            }
        }

        if(health > max_health)
        {
            health = max_health;
        }

        if(health<= 0.0f)
        {
            //player is dead
        }
	}

    public void Attack(float delay)
    {
        if(!ranged)
        {
            new_delay = delay;
        }
        else
        {
            RangedAttack(0);
        }
    }

    public void RangedAttack(int proj_num)
    {
        GameObject projectile = OP.GetPooledObject(proj_num);
        Vector2 player_offset = new Vector2(transform.position.x - player_sprite_offset.x, transform.position.y - player_sprite_offset.y);
        projectile.transform.position = player_offset;
        Vector2 dir = new Vector2(ranged_aim_pos.x - player_offset.x, ranged_aim_pos.y - player_offset.y);
        float angle = (Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg) - 90;
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        projectile.GetComponent<ProjectileScript>().Reset();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //take damage from enemy
        }
    }

    public void AddHealth(float amount)
    {
        health += amount;
    }
}
