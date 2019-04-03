using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndBossScene : MonoBehaviour {

    public List<GameObject> enemies;
    public SceneController sc;
    public GameObject boss;

    // Use this for initialization
    void Start () {
        
	}

	// Update is called once per frame
	void Update () {
        if (boss == null) {
            endGame();
        }
      
    }

    void endGame()
    {
        sc = FindObjectOfType<SceneController>();
        sc.MenuScene();
    }
}
