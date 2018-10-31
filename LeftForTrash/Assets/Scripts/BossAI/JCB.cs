using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCB : Boss {

	// Use this for initialization
	void Start () {
		base.setup();
	}
	
	// Update is called once per frame
	void Update () {
		base.update();

		if((Time.time - time) >= waitTime && state == State.WAIT)
		{
			state = State.ATTACK_1;
			time = Time.time;
		}else if(animator.GetCurrentAnimatorStateInfo(0).IsName("JCB_idle")){
			state = State.WAIT;
			animator.SetBool("attack_1", false);
		}

		processState();
	}

	private void processState(){
		switch(state){
			case State.ATTACK_1:
			//Attack logic
			animator.SetBool("attack_1", true);
			break;
			case State.WAIT:
			//Do nothing
			break;
		}
	}	
}
