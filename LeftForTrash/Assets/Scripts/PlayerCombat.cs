using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    public InputManager input;
    public GameObject attack_spawn;
    public Vector2 offset;
    private Vector2 attack_pos;
    public GameObject Attack_Collider;
    private float new_delay;
    private ObjectPooler OP;
    

	void Start () {
        input = GetComponent<InputManager>();
        OP = GetComponent<ObjectPooler>();
	}
	
	void Update () {

        Vector2 direction = new Vector2(input.getHorizontal(), input.getVertical());
        attack_pos = new Vector2(transform.position.x - offset.x, transform.position.y - offset.y);

        //ranged attack direction
        if (direction.x > 0)
        {
            attack_pos.x += (direction.x / 3);
            attack_spawn.transform.position = new Vector3(attack_pos.x, attack_pos.y);
        }
        else if(direction.x < 0)
        {
            attack_pos.x += (direction.x / 3);
            attack_spawn.transform.position = new Vector3(attack_pos.x, attack_pos.y);
        }

        if (direction.y > 0)
        {
            attack_pos.y += (direction.y / 3);
            attack_spawn.transform.position = new Vector3(attack_pos.x, attack_pos.y);
        }
        else if (direction.y < 0)
        {
            attack_pos.y += (direction.y / 3);
            attack_spawn.transform.position = new Vector3(attack_pos.x, attack_pos.y);
        }

        

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

    public void Attack(float delay)
    {
        new_delay = delay;
    }

    public void RangedAttack()
    {
        GameObject projectile = OP.GetPooledObject();
        projectile.transform.position = transform.position;
        Vector2 dir = new Vector2(attack_pos.x - transform.position.x, attack_pos.y - transform.position.y);
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
}
