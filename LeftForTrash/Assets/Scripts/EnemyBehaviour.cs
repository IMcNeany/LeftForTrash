using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    float speed = 0.3f;
    public List<GameObject> playerList;
    public GameObject Attack_Collider;
    public float enemyHealth = 100;
    public Transform prefab;
    private Animator animator;
    public List<AnimationClip> animation_clips;
    Movement followPlayer;
    float delay;
    float new_delay;
    bool follow;
    public float distanceFromPlayer;

    public Transform drop;
    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    bool PlayerWithInSight()
    {
        if (playerList.Count > 0)
        {
            for (int i = 0; i < playerList.Count; i++)
            {
               float angle = Vector3.Angle(playerList[i].GetComponent<Movement>().GetPosition(),gameObject.transform.forward);
                if(angle < 20.0f)
                {
                    return true;
                }
            }
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {

        if(enemyHealth <= 0)
        {          
            //death
            StartCoroutine(Death());
        }
        else if(follow)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, followPlayer.GetPosition(), speed * Time.deltaTime);

            //needs to be within range
            distanceFromPlayer = Vector3.Distance(gameObject.transform.position, followPlayer.GetPosition());
            if (distanceFromPlayer <= 1.5)
            {
                animator.SetBool("Walking", false);
                animator.SetBool("Punching", true);
                //animator.Play(animation_clips[0].name);
                delay = animation_clips[0].length;
                Attack(delay);
                if (new_delay > 0.0f)
                {
                    new_delay -= 1 * Time.deltaTime;
                    Attack_Collider.SetActive(true);
                }
                else
                {
                    Attack_Collider.SetActive(false);
                  
                }
            }
            else
            {
                // animator.StopPlayback();
                //animator.Play(animation_clips[2].name);
                animator.SetBool("Punching", false);
                animator.SetBool("Walking", true);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //need to add line of sight
        if (other.GetComponent<Movement>())
        {
            playerList.Add(other.gameObject);
        }

       
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (playerList.Count > 0)
        {
            float minDist = Mathf.Infinity;
            int playerNo;
            Movement followPlayer = playerList[0].GetComponent<Movement>();
            //for each player figure out the distance away
            for (int i = 0; i < playerList.Count; i++)
            {
                Movement player = playerList[i].GetComponent<Movement>();
                float dist = Vector3.Distance(gameObject.transform.position, player.GetPosition());
                if (dist < minDist)
                {
                    minDist = dist;
                    playerNo = i;
                    followPlayer = playerList[i].GetComponent<Movement>();
                }
            }
            //follow closest player
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, followPlayer.GetPosition(), speed * Time.deltaTime);
            if(followPlayer.GetPosition().x < gameObject.transform.position.x)
            {
               
                gameObject.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
            }
            else
            {
                gameObject.transform.localRotation = new Quaternion(0.0f, 180.0f, 0.0f, 1.0f);
            }
            follow = true;
            
            animator.SetBool("Walking", true);
            //animator.Play(animation_clips[2].name);
            //needs to be within range
            distanceFromPlayer = Vector3.Distance(gameObject.transform.position, followPlayer.GetPosition());
            if (distanceFromPlayer <= 1.5)
            {
                //animator.StopPlayback();
                animator.SetBool("Punching", false);
                animator.SetBool("Walking", true);
                // animator.Play(animation_clips[0].name);
                delay = animation_clips[0].length;
                Attack(delay);
               
            }
            
        }
    }

    void Attack(float delay)
    {
        animator.SetBool("Walking", false);
        new_delay = delay;


    }
    void OnTriggerExit2D(Collider2D other)
    {
        //remove player
        for (int i = 0; i < playerList.Count; i++)
        {
            if (playerList[i] == other.gameObject)
            {
                playerList.RemoveAt(i);
            }
        }
        animator.SetBool("Idle", true);
        animator.SetBool("walking", false);
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }

    IEnumerator Death()
    {
        animator.SetBool("Punching", false);
        animator.SetBool("Fall", true);
        //animator.Play(animation_clips[1].name);
        follow = false;
        yield return new WaitForSeconds(2.5f);
        Instantiate(drop, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(this.gameObject);
    }
}
