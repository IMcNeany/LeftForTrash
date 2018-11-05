using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Elements : MonoBehaviour
{
    [Header("Timer Values")]

    [SerializeField]
    private Text uiText;
    [SerializeField] private float seconds = 100.0f; //How many seconds
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    [Header("FPS Values")]

    public Text FPSText;
    private int frameRate;

    [Header("Score Values")]
    public Text Player1Text;
    public Text Player2Text;
    public Text Player3Text;
    public Text Player4Text;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    private PlayerCombat player1Combat;
    private PlayerCombat player2Combat;
    private PlayerCombat player3Combat;
    private PlayerCombat player4Combat;
    private GameObject gm;
    public bool player1Active = false;
    private bool player2Active = false;
    private bool player3Active = false;
    private bool player4Active = false;

    //public int score;

    void Start()
    {
        gm = GameObject.FindWithTag("GameController");
        player1Active = gm.GetComponent<DataPersistance>().player1Active;
        player2Active = gm.GetComponent<DataPersistance>().player2Active;
        player3Active = gm.GetComponent<DataPersistance>().player3Active;
        player4Active = gm.GetComponent<DataPersistance>().player4Active;

        timer = seconds;

        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
        player3 = GameObject.Find("Player 3");
        player4 = GameObject.Find("Player 4");

        player1Combat = player1.GetComponent<PlayerCombat>();
        player2Combat = player2.GetComponent<PlayerCombat>();
        player3Combat = player3.GetComponent<PlayerCombat>();
        player4Combat = player4.GetComponent<PlayerCombat>();

    }

    private void ScoreValue()
    {
        if (player1Active == true)
        {
            Player1Text.text = "Score: " + player1Combat.score;
        }
        if (player2Active == true)
        {
            Player2Text.text = "Score: " + player2Combat.score;
        }
        if (player3Active == true)
        {
            Player3Text.text = "Score: " + player3Combat.score;
        }
        if (player4Active == true)
        {
            Player4Text.text = "Score: " + player4Combat.score;
        }
    }

    void Update()
    {
        FPSCounter();
        ScoreValue();
        GameTimer();
        FormatTimer();
    }

    private void GameTimer()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= 1 * Time.deltaTime;
            uiText.text = timer.ToString("F");
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
        }
    }

    private void FormatTimer() //Changes seconds to minutes
    {
        string minutes = Mathf.Floor(timer / 60).ToString("00");
        string seconds = (timer % 60).ToString("00");
        uiText.text = "Time Left: " + minutes + " : " + seconds;
    }

    private void FPSCounter()
    {
        float current = 0;
        current = Time.frameCount / Time.time;
        frameRate = (int)current;
        FPSText.text = frameRate.ToString() + " FPS";
    }


}