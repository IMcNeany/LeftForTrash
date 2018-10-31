using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public enum State{
		WAIT,
		ATTACK_1
		
	}

	//public UI healthbar

	public float health;
	public float damageScale;
	public float waitTime;
	public State state; //Public for debug

	protected float time;
	protected Animator animator;

	// Use this for initialization
	protected void setup () {
		state = State.WAIT;
		animator = GetComponent<Animator>();
		time = Time.time;
	}

	protected void update(){

	}
}
