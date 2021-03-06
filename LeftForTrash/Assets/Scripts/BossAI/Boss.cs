﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public enum State{
		WAIT,
		ATTACK_1,
		ATTACK_2,
		PROCESS,
        DIE,
	}


	public float health;
	public float maxHealth;
	public float damageScale;
	public float waitTime;
	public State state; //Public for debug
	public GameObject healthbar;

	protected float time;
	protected Animator animator;

	// Use this for initialization
	protected void setup () {
		state = State.WAIT;
		animator = GetComponent<Animator>();
		time = Time.time;
	}

	protected void update(){
		float ratio = health/maxHealth;
        if (healthbar)
        {
            healthbar.GetComponent<RectTransform>().localScale = new Vector3(ratio, 1, 1);
        }

        if(ratio <= 0)
        {
            ratio = 0;
        }
	}

	public void hit(float damage) {
        if(health > 1)
        {
		    health -= damage;
        }
	}
}
