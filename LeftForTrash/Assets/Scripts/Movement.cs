using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Quaternion rotationDirection;
    private InputManager input;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb2d;
    private Vector2 movement;
    public float delay = 0.0f;
    private Animator animator;
    public List<AnimationClip> animation_clips;
    public float speed = 5.0f;
    public int sprite_direction = 1;
    private PlayerCombat combat;
    private SpecialAttack special;
    private Player2Special P2S;
    public bool move_during_special = false;

    // Use this for initialization
    void Start () {
        input = GetComponent<InputManager>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        combat = GetComponent<PlayerCombat>();
        special = GetComponent<SpecialAttack>();

        if(special is Player2Special)
        {
            P2S = special as Player2Special;    
        }
    }
	
	// Update is called once per frame
	void Update () {
        UpdateMovement();
	}

    void UpdateMovement()
    {
        if (P2S)
        {
            animator.SetFloat("Delay", P2S.current_spintime);
        }
        
        if (delay <= 0.0f)
        {
            movement = new Vector2(input.getHorizontal() * speed, input.getVertical() * speed);

            if (input.getButtons(1))
            {
                animator.Play(animation_clips[0].name);
                delay = animation_clips[0].length;
                combat.Attack(delay);
            }
            if (input.getButtons(0))
            {
                if (special.current_cooldown <= 0.0f)
                {
                    animator.Play(animation_clips[1].name);
                    
                    if(special.override_delay)
                    {
                        delay = P2S.spin_time;
                    }
                    else
                    {
                        delay = animation_clips[1].length;
                    }
                    special.UseSpecialAttack();
                }
            }
        }
        else
        {
            movement = Vector2.zero;
            delay -= 1 * Time.deltaTime;
        }
        if (P2S)
        {
            if (move_during_special && animator.GetFloat("Delay") > 0.0f)
            {
                movement = new Vector2(input.getHorizontal() * speed, input.getVertical() * speed);
            }
        }
        if (movement != Vector2.zero)
        {
            if (movement.x > 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = sprite_direction;
                transform.transform.localScale = scale;
            }
            else if (movement.x < 0)
            {
                Vector3 scale = transform.localScale;
                scale.x = -sprite_direction;
                transform.transform.localScale = scale;
            }

            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }

    private void FixedUpdate()
    {
          rb2d.MovePosition(rb2d.position + movement * Time.fixedDeltaTime);
        
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

   
}

