using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAttack : MonoBehaviour {

    public float special_delay = 5.0f;
    public float current_delay = 0.0f;
    void Start () {
		
	}
	
	void Update () {
		if(current_delay > 0.0f)
        {
            current_delay -= 1 * Time.deltaTime;
        }
	}

    public virtual void UseSpecialAttack()
    {

    }
}
