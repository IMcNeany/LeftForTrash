using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Special : SpecialAttack {

    public float spin_time = 4.0f;
    public float current_spintime = 0.0f;
    public GameObject spin_hitbox;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {

        base.Update();
		if(current_spintime > 0.0f)
        {
            current_spintime -= 1 * Time.deltaTime;
        }
        else
        {
            spin_hitbox.SetActive(false);
        }
	}
    public override void UseSpecialAttack()
    {
        current_spintime = spin_time;
        spin_hitbox.SetActive(true);
        base.UseSpecialAttack();
    }
}
