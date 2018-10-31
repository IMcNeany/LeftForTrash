using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {
    public float speed = 5.0f;
    public float life_time = 3.0f;
    public float current_lifetime;

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
}
