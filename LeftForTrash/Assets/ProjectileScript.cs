using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {
    public GameObject hit_effect_prefab;
    public float speed = 5.0f;
    public float life_time = 3.0f;
    public float current_lifetime;
    public float damage;
    public bool heal = false;

    public void Reset()
    {
        current_lifetime = life_time;
        gameObject.SetActive(true);
    }

    void Update () {
        current_lifetime -= 1 * Time.deltaTime;
        if(current_lifetime <= 0.0f)
        {
            gameObject.SetActive(false);
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.tag == "Nocollide")
        {

        }
        else if(trigger.tag != "Player")
        {
            if (hit_effect_prefab)
            {
                GameObject hit_effect = Instantiate(hit_effect_prefab, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            }
            gameObject.SetActive(false);

        }
        else if(trigger.gameObject.name != "Player 1" && heal == true)
        {
            if (hit_effect_prefab)
            {
                GameObject hit_effect = Instantiate(hit_effect_prefab, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            }
            trigger.gameObject.GetComponent<PlayerCombat>().AddHealth(20);
            gameObject.SetActive(false);
        }

        
    }
}
