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
    public float base_speed = 5.0f;
    public float current_speed = 5.0f;
    public int sprite_direction = 1;
    private PlayerCombat combat;
    private SpecialAttack special;
    private Player2Special P2S;
    public bool move_during_special = false;
    public float buff_time = 5.0f;
    public float current_buff_time = 0.0f;

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
            movement = new Vector2(input.getHorizontal() * current_speed, input.getVertical() * current_speed);

            if (input.getTrigger() < -0.2f)
            {
                animator.Play(animation_clips[0].name);
                delay = animation_clips[0].length;
                combat.Attack(delay);
            }
            if (input.getTrigger() > 0.2f)
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
                movement = new Vector2(input.getHorizontal() * current_speed, input.getVertical() * current_speed);
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

        if(current_buff_time < 0.0f)
        {
            current_speed = base_speed;
        }
        else
        {
            current_buff_time -= 1 * Time.deltaTime;
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

    public void BuffSpeed(float amount)
    {
        current_buff_time = buff_time;
        current_speed = amount;
    }

   
}

