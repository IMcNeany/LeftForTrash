using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour {
	public float delay = 0.2f;
	public float warnTime = 5.0f;
	public float holdTime = 1.0f;

	private float time, lastTime;

	private Sprite mark;
	private SpriteRenderer renderer;
	private Animator animator;

	// Update is called once per frame
	void Update () {
		float elapsedTime = Time.time - time;

		if(elapsedTime >= warnTime){
			renderer.enabled = true;
			if(elapsedTime >= warnTime + holdTime){
				animator.SetBool("exploded", true);
			}
		} else if(elapsedTime >= delay + lastTime){
			renderer.enabled = !renderer.enabled;
			lastTime = elapsedTime;
		}

		if(animator.GetCurrentAnimatorStateInfo(0).IsName("End")){
			this.gameObject.SetActive(false);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.tag == "Player")
        {
            Debug.Log("EXPLODE!");
        }
    }

	public void setup () {
		time = Time.time;
		lastTime = 0;
		renderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
		mark = renderer.sprite;
	}

	public void reset(){
		time = Time.time;
		lastTime = 0;
		animator.SetBool("exploded", false);
		renderer.enabled = true;
		renderer.sprite = mark;
	}
}
