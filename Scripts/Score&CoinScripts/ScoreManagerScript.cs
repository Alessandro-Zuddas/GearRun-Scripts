using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManagerScript : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject highScoreObject;
    public GameObject panelObj;
    public Text highScoreText;
    public Text currentScoreText;

    public GameObject doubleCoinsPanel;
    public GameObject doubleScorePanel;
    public GameObject shieldIconPanel;

   

    public Text earnedCoins;
    int coins = 0;

    public Text scoreText;
    public int score;
    public GameObject scoreTxtObj;

    public static ScoreManagerScript scoreScript;                 //Dichiarazione per poter richiamare elementi di questo script da un altro

    public bool scoreForFour;
    public bool normalScoreOn;
    public bool highScorePlayed;
    public AudioClip highScoreFx;
    public AudioClip gameOverSound;

    private void Awake()
    {
        if (scoreScript == null)
        {
            scoreScript = this;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        normalScoreOn = true;
        scoreForFour = false;
        score = 0;
        scoreText.text = score.ToString();
        highScorePlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
      
    }


    public void StartScore()
    {
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
        scoreTxtObj.SetActive(true);
    }

    void IncrementScore()
    {
        if(normalScoreOn)
        {
            score += 1;
            scoreText.text = score.ToString();
            // Debug.Log("Score +1");
            //controllo se ha superato l'highscore

            if (PlayerPrefs.HasKey("highScore") && !highScorePlayed)
            {
                if (score > PlayerPrefs.GetInt("highScore"))
                {
                    highScoreObject.SetActive(true);
                    AudioManagerScript.audioScript.PlaySound(highScoreFx);
                    highScorePlayed = true;
                }
            }

        }
        else if(!normalScoreOn)
        {
            Debug.Log("Sei nel +2");
            score += 2;
            scoreText.text = score.ToString();

            //controllo se ha superato l'highscore

            if (PlayerPrefs.HasKey("highScore") && !highScorePlayed)
            {
                if (score > PlayerPrefs.GetInt("highScore"))
                {
                    highScoreObject.SetActive(true);
                    AudioManagerScript.audioScript.PlaySound(highScoreFx);
                    highScorePlayed = true;
                }
            }
        }

        if(PlayerScript.playerScript.goldenGearIsOn)
        {
            score += 1;
            scoreText.text = score.ToString();
            // Debug.Log("Score +1");
            //controllo se ha superato l'highscore

            if (PlayerPrefs.HasKey("highScore") && !highScorePlayed)
            {
                if (score > PlayerPrefs.GetInt("highScore"))
                {
                    highScoreObject.SetActive(true);
                    AudioManagerScript.audioScript.PlaySound(highScoreFx);
                    highScorePlayed = true;
                }
            }
        }

        if(scoreForFour)
        {

            Debug.Log("Sei nel +4");
            score += 3;
            scoreText.text = score.ToString();

            //controllo se ha superato l'highscore

            if (PlayerPrefs.HasKey("highScore") && !highScorePlayed)
            {
                if (score > PlayerPrefs.GetInt("highScore"))
                {
                    highScoreObject.SetActive(true);
                    AudioManagerScript.audioScript.PlaySound(highScoreFx);
                    highScorePlayed = true;
                }
            }
        }
    }

    public void StopScore()
    {
            doubleCoinsPanel.SetActive(false);
            doubleScorePanel.SetActive(false);
            shieldIconPanel.SetActive(false);


        CancelInvoke("IncrementScore");

            //Registro il risultato di score

            PlayerPrefs.SetInt("score", score);

            //Registro l'HighScore

            if (PlayerPrefs.HasKey("highScore"))
            {
                if (score > PlayerPrefs.GetInt("highScore"))
                {
                    PlayerPrefs.SetInt("highScore", score);
                    LadeboardManager.leaderboardScript.SubmitScore();
                }
            }
            else
            {
                PlayerPrefs.SetInt("highScore", score);
                LadeboardManager.leaderboardScript.SubmitScore();
            }

            //Assegno i valori di score e highscore alla label del game over
            highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
            currentScoreText.text = PlayerPrefs.GetInt("score").ToString();
            

            //faccio scomparire il game panel e faccio apparire il gameover panel
            gamePanel.SetActive(false);
            panelObj.SetActive(true);
    }


    
}
