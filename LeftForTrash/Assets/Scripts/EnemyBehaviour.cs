using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    float speed = 0.3f;
    public List<GameObject> playerList;
    public GameObject Attack_Collider;
    public float enemyHealth = 100;
    private Animator animator;
    public List<AnimationClip> animation_clips;
    Movement followPlayer;
    public float delay;
    public float new_delay;
    bool follow = false;
    public float distanceFromPlayer;
    Vector3 firstPos;
    float time = 5;
    float timer;
    bool startTimer;
    [Header("Drop Values")]

    int spawn_rand = 0;
    public GameObject scoreDrop;
    public GameObject speedDrop;
    public GameObject healthDrop;

    // Use this for initialization
    void Start()
    {
        followPlayer = null;
        animator = GetComponent<Animator>();

        firstPos = gameObject.transform.position;
        timer = animation_clips[0].length;

    }

    // Update is called once per frame
    void Update()
    {

        if (enemyHealth <= 0)
        {
            //death
            enemyHealth = 0;
            StartCoroutine(Death());
        }
        else if (follow)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, followPlayer.GetPosition(), speed * Time.deltaTime);

            //needs to be within range
            distanceFromPlayer = Vector3.Distance(gameObject.transform.position, followPlayer.GetPosition());

            if (distanceFromPlayer <= 1.5)
            {
                animator.SetBool("Walking", false);
                Debug.Log("dist");
                //animator.Play(animation_clips[0].name);
                delay = animation_clips[0].length;
                /*
                if (new_delay <= 0.0f)
                {

                    Debug.Log("delay < 0");
                    Attack_Collider.SetActive(false);
                }
                else
                {
                    Debug.Log("delay > 0");
                    new_delay -= 1 * Time.deltaTime;
                    Attack_Collider.SetActive(true);
                    //Attack(delay);

                }*/
                if(startTimer)
                {
                    time -= Time.deltaTime;
                    Debug.Log(startTimer+ " timer" + time);
                }

                if(time <= 0.0f)
                {
                    Debug.Log("time <0");
                    Attack_Collider.SetActive(false);
                    startTimer = false;
                    Attack(delay);
                }
                else
                {
                    Debug.Log("time >0");
                    Attack_Collider.SetActive(true);
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
            followPlayer = playerList[0].GetComponent<Movement>();
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
            if (followPlayer.GetPosition().x < gameObject.transform.position.x)
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
                animator.SetBool("Walking", false);
                // animator.Play(animation_clips[0].name);
                delay = animation_clips[0].length;
                if (!startTimer)
                {
                    Attack(delay);
                }
            }
            else
            {
                animator.SetBool("Punching", false);
            }


        }
    }

    void Attack(float delay)
    {
        animator.SetBool("Walking", false);
        animator.SetBool("Punching", true);
        time = timer;
        startTimer = true;
        Debug.Log("startTimer");
       // new_delay = delay;


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
        if (playerList.Count == 0)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, firstPos, speed * Time.deltaTime);
            follow = false;

        }
        animator.SetBool("Idle", true);
        animator.SetBool("Walking", false);
    }

    public void TakeDamage(float damage)
    {
        enemyHealth -= damage;
    }

    IEnumerator Death()
    {
        follow = false;
        animator.SetBool("Punching", false);
        animator.SetBool("Fall", true);

        yield return new WaitForSeconds(2.5f);
        Vector3 pos = transform.position;
        spawn_rand = Random.Range(1,5);

        switch (spawn_rand)
        {
            case 1:
                Instantiate(healthDrop, pos, gameObject.transform.rotation);
                Debug.Log("has spawned health");
                break;
            case 2:
                Instantiate(speedDrop, pos, gameObject.transform.rotation);
                Debug.Log("has spawned speed");
                break;
            case 3:
            case 4:
            case 5:
                Instantiate(scoreDrop, pos, gameObject.transform.rotation);
                Debug.Log("has spawned score");
                break;
        }
        Destroy(gameObject);
    }
}
