﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCB : Boss {

	public GameObject bombsStartPosition;
	public GameObject bombPrefab;
	public int width;
	public int height;
    public int totalBombs = 5;

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
            switch (Random.Range(1, 3)) {
                case 1:
                    state = State.ATTACK_1;
                    break;
                case 2:
                    state = State.ATTACK_2;
                    break;
            }
			
			time = Time.time;
		}else if(animator.GetCurrentAnimatorStateInfo(0).IsName("JCB_idle")){
			state = State.WAIT;
			animator.SetBool("attack_1", false);
			animator.SetBool("attack_2", false);
		}

        if (health <= 0 && state != State.PROCESS) {
            health = 0;
            state = State.DIE;
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
            Invoke("activateBombs", 0.5f);
			break;
			case State.WAIT:
			//Do nothing
			break;
            case State.DIE:
                animator.SetBool("die", true);
                GetComponent<SpriteRenderer>().color = Color.black;
                Invoke("die", 5.0f);
            break;
		}

		if(state != State.WAIT)
			state = State.PROCESS;
	}

	private void activateBombs(){
        for (int i = 0; i < totalBombs; i++) {
            GameObject bomb = bombs[Random.Range(0, bombs.Length)];
            bomb.SetActive(true);
            bomb.GetComponent<BombAttack>().reset();
        }
	}

    private void die() {
        Debug.Log("Rip Boss");
        Destroy(this.gameObject);
    }
}
