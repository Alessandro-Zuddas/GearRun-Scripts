using CloudOnce;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LadeboardManager : MonoBehaviour
{
    public Text highScoreText;

    public int score;

    public static LadeboardManager leaderboardScript;

    private void Awake()
    {
        if(leaderboardScript == null)
        {
            leaderboardScript = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Cloud.OnInitializeComplete += CloudOnceInitializeComplete;
        Cloud.Initialize(false, true);

        score = PlayerPrefs.GetInt("highScore");
    }

   
    public void CloudOnceInitializeComplete()
    {
        Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
        Debug.LogWarning("Initialized");
    }

    public void SubmitScore()
    {
        Leaderboards.GearRunHallOfFame.SubmitScore(score);
    }

}
