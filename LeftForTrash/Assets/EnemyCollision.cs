using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    public EnemyBehaviour EB;
    public Boss boss;
	// Use this for initialization
	void Start () {
		
        
	}
	
	// Update is called once per frame
	void Update () {
		
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
}
