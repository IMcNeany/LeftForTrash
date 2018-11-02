using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour {

    public float special_cooldown = 5.0f;
    public float current_cooldown = 0.0f;
    public bool override_delay = false;
	
	public virtual void Update () {
		if(current_cooldown > 0.0f)
        {
            current_cooldown -= 1 * Time.deltaTime;
        }
	}

    public virtual void UseSpecialAttack()
    {

    }
}
