using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {

    public InputManager input;
    public Vector2 offset;
    private Vector2 attack_pos;
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
        attack_pos = new Vector2(transform.position.x - offset.x, transform.position.y - offset.y);

        //ranged attack direction
        if (direction.x > 0)
        {
            attack_pos.x += (direction.x / 3);
        }
        else if(direction.x < 0)
        {
            attack_pos.x += (direction.x / 3);
        }

        if (direction.y > 0)
        {
            attack_pos.y += (direction.y / 3);
        }
        else if (direction.y < 0)
        {
            attack_pos.y += (direction.y / 3);
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
	}

    public void Attack(float delay)
    {
        if(!ranged)
        {
            new_delay = delay;
        }
        else
        {
            RangedAttack();
        }
    }

    public void RangedAttack()
    {
        GameObject projectile = OP.GetPooledObject();
        Vector2 player_offset = new Vector2(transform.position.x - offset.x, transform.position.y - offset.y);
        projectile.transform.position = player_offset;
        Vector2 dir = new Vector2(attack_pos.x - player_offset.x, attack_pos.y - player_offset.y);
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
