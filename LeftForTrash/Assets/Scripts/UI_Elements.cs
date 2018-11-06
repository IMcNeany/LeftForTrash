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

    [Header("Health Values")]
    //Player Select Bar Amount
    public Image Player1HP;
    public Image Player2HP;
    public Image Player3HP;
    public Image Player4HP;
    //HP Loss
    public Image P1HPLoss;
    public Image P2HPLoss;
    public Image P3HPLoss;
    public Image P4HPLoss;

    public Text TempHP1Text;
    public Text TempHP2Text;
    public Text TempHP3Text;
    public Text TempHP4Text;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    private PlayerCombat player1Combat;
    private PlayerCombat player2Combat;
    private PlayerCombat player3Combat;
    private PlayerCombat player4Combat;

    private Player1Special player1Cooldown;
    private Player2Special player2Cooldown;
    private Player3Special player3Cooldown;
    private Player4Special player4Cooldown;

    [Header("Score Values")]
    public Text Player1Text;
    public Text Player2Text;
    public Text Player3Text;
    public Text Player4Text;

    [Header("Cooldown Values")]
    public Text Player1CD;
    public Text Player2CD;
    public Text Player3CD;
    public Text Player4CD;

    public void Init()
    {
        timer = seconds;

        player1Combat = player1.GetComponent<PlayerCombat>();
        player2Combat = player2.GetComponent<PlayerCombat>();
        player3Combat = player3.GetComponent<PlayerCombat>();
        player4Combat = player4.GetComponent<PlayerCombat>();

        player1Cooldown = player1.GetComponent<Player1Special>();
        player2Cooldown = player2.GetComponent<Player2Special>();
        player3Cooldown = player3.GetComponent<Player3Special>();
        player4Cooldown = player4.GetComponent<Player4Special>();

        if (player1.activeInHierarchy)
        {
            Player1Text.gameObject.SetActive(true);
            Player1HP.gameObject.SetActive(true);
            Player1CD.gameObject.SetActive(true);
            TempHP1Text.gameObject.SetActive(true);
        }
        if (player2.activeInHierarchy)
        {
            Player2Text.gameObject.SetActive(true);
            Player2HP.gameObject.SetActive(true);
            Player2CD.gameObject.SetActive(true);
            TempHP2Text.gameObject.SetActive(true);
        }
        if (player3.activeInHierarchy)
        {
            Player3Text.gameObject.SetActive(true);
            Player3HP.gameObject.SetActive(true);
            Player3CD.gameObject.SetActive(true);
            TempHP3Text.gameObject.SetActive(true);
        }
        if (player4.activeInHierarchy)
        {
            Player4Text.gameObject.SetActive(true);
            Player4HP.gameObject.SetActive(true);
            Player4CD.gameObject.SetActive(true);
            TempHP4Text.gameObject.SetActive(true);
        }
     
    }
    
    void Update()
    {
        FPSCounter();
        ScoreValue();
        HealthBar();
        GameTimer();
        FormatTimer();
    }

    private void HealthBar()
    {
        P1HPLoss.fillAmount = player1Combat.health / player1Combat.max_health;
        P1HPLoss.GetComponent<RectTransform>().localScale = new Vector3(P1HPLoss.fillAmount, 1, 1);
        P2HPLoss.fillAmount = player2Combat.health / player2Combat.max_health;
        P2HPLoss.GetComponent<RectTransform>().localScale = new Vector3(P2HPLoss.fillAmount, 1, 1);
        P3HPLoss.fillAmount = player3Combat.health / player3Combat.max_health;
        P3HPLoss.GetComponent<RectTransform>().localScale = new Vector3(P3HPLoss.fillAmount, 1, 1);
        P4HPLoss.fillAmount = player4Combat.health / player4Combat.max_health;
        P4HPLoss.GetComponent<RectTransform>().localScale = new Vector3(P4HPLoss.fillAmount, 1, 1);
    }

    private void ScoreValue()
    {
        Player1Text.text = "Score: " + player1Combat.score;
        Player2Text.text = "Score: " + player2Combat.score;
        Player3Text.text = "Score: " + player3Combat.score;
        Player4Text.text = "Score: " + player4Combat.score;

        TempHP1Text.text = "HP: " + player1Combat.health;
        TempHP2Text.text = "HP: " + player2Combat.health;
        TempHP3Text.text = "HP: " + player3Combat.health;
        TempHP4Text.text = "HP: " + player4Combat.health;

        Player1CD.text = "Cooldown: " + Mathf.Round(player1Cooldown.current_cooldown);
        Player2CD.text = "Cooldown: " + Mathf.Round(player2Cooldown.current_cooldown);
        Player3CD.text = "Cooldown: " + Mathf.Round(player3Cooldown.current_cooldown);
        Player4CD.text = "Cooldown: " + Mathf.Round(player4Cooldown.current_cooldown);
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