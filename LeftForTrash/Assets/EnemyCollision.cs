using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    public EnemyBehaviour EB;
    public Boss boss;
    private float damage_tick = 0.2f;
    private bool spin_damage = false;
	// Use this for initialization
	void Start () {
		
        
	}
	
	// Update is called once per frame
	void Update () {
		//this is for p2 spin attack sorry about spaghetti code
        if(spin_damage)
        {
            damage_tick -= 1 * Time.deltaTime;
            if(damage_tick <= 0.0f)
            {
                float damage = 20;
                if (EB)
                {
                    EB.TakeDamage(damage);
                }

                if (boss && boss.health > 1)
                {
                    boss.hit(damage);
                }
                damage_tick = 0.2f;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float damage = 0;
        if(collision.tag == "Melee")
        {
            damage = 10;
        }

        if(collision.tag == "Projectile")
        {
            damage = collision.GetComponent<ProjectileScript>().damage;
        }

        if(EB)
        {
            EB.TakeDamage(damage);
        }

        if(boss)
        {
            boss.hit(damage);
        }


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.name == "Spin_Hitbox")
        {
            spin_damage = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Spin_Hitbox")
        {
            spin_damage = false;
        }
    }
}
