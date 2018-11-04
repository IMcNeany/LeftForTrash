using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

	public enum State{
		WAIT,
		ATTACK_1
		
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
		healthbar.GetComponent<RectTransform>().localScale = new Vector3(ratio, 1, 1);
	}

	public void hit(/* player instance */){
		float damage = 1.0f; //Player.getDamage()

		health -= damage;
	}
}
