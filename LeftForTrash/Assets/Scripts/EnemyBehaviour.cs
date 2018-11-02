using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    float speed = 0.3f;
    public List<GameObject> playerList;
    public Transform prefab;

    // Use this for initialization
    void Start()
    {

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
        }
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
    }
}
