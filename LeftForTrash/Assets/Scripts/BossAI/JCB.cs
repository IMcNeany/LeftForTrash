using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCB : Boss {

	public GameObject bombsStartPosition;
	public GameObject bombPrefab;
	public int width;
	public int height;

	private GameObject[]  bombs;

	// Use this for initialization
	void Start () {
		base.setup();
		instantiateBombs();
	}
	
	// Update is called once per frame
	void Update () {
		base.update();

		if((Time.time - time) >= waitTime && state == State.WAIT)
		{
			state = State.ATTACK_2;
			time = Time.time;
		}else if(animator.GetCurrentAnimatorStateInfo(0).IsName("JCB_idle")){
			state = State.WAIT;
			animator.SetBool("attack_1", false);
			animator.SetBool("attack_2", false);
		}

		processState();
	}

	private void instantiateBombs(){
		bombs = new GameObject[width * height];
		for(int y = 0; y < height; y++){
			for(int x = 0; x < width; x++){
				Vector3 newPos = bombsStartPosition.transform.position + new Vector3(x, y, -1);
				GameObject newBomb = Instantiate(bombPrefab, newPos, Quaternion.identity);
				newBomb.transform.parent = bombsStartPosition.transform;
				newBomb.GetComponent<BombAttack>().setup();
				newBomb.SetActive(false);
				bombs[x + y * width] = newBomb;
			}
		}
	}

	private void processState(){
		switch(state){
			case State.ATTACK_1:
			//Attack logic
			animator.SetBool("attack_1", true);
			break;
			case State.ATTACK_2:
			animator.SetBool("attack_2", true);
			activateBombs();
			break;
			case State.WAIT:
			//Do nothing
			break;
		}

		if(state != State.WAIT)
			state = State.PROCESS;
	}

	private void activateBombs(){
		//Choose area
		//Active and reset

		foreach(GameObject bomb in bombs){
			bomb.SetActive(true);
			bomb.GetComponent<BombAttack>().reset();
		}
	}
}
