using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAttack : MonoBehaviour {
	public float delay = 0.2f;
	public float warnTime = 5.0f;
	public float holdTime = 1.0f;

	private float time, lastTime;

	private SpriteRenderer renderer;
	private Animator animator;

	// Use this for initialization
	void Start () {
		lastTime = time = Time.time;
		renderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}
	
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
			lastTime = Time.time;
		}

		if(animator.GetCurrentAnimatorStateInfo(0).IsName("End")){
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
    {
		if(col.gameObject.tag == "Player")
        {
            Debug.Log("EXPLODE!");
        }
    }
}
