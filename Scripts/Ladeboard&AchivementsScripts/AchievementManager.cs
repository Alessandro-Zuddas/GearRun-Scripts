using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CloudOnce;

public class AchievementManager : MonoBehaviour
{
    public Text highscoreText;
    public Text coinText;

    public int score;
    public int coins;

    public static AchievementManager achievementScript;

    private void Awake()
    {
        if(achievementScript == null)
        {
            achievementScript = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        Cloud.Initialize(false, true);
        Cloud.OnInitializeComplete += CloudOnceInitializeComplete;

        score = PlayerPrefs.GetInt("highScore");
        coins = PlayerPrefs.GetInt("coins");
    }

    private void Update()
    {
        CheckForAchievements();
    }


    public void CloudOnceInitializeComplete()
    {
        Cloud.OnInitializeComplete -= CloudOnceInitializeComplete;
        Debug.LogWarning("Initialize");
    }

    public void CheckForAchievements()
    {
        Debug.Log("Sto Controllando");

        if(score == 250)
        {
            Achievements.Beginner.Unlock();
            Debug.LogWarning("Unlocked Beginner");
        }
        
        if(score == 500)
        {
            Achievements.Intermediate.Unlock();
            Debug.LogWarning("Unlocked Intermediate");
        }
       
        if(score == 750)
        {
            Achievements.Expert.Unlock();
            Debug.LogWarning("Unlocked Expert");
        }
        
        if(score == 1000)
        {
            Achievements.Pro.Unlock();
            Debug.LogWarning("Unlocked Pro");
        }

        if(coins == 500000)
        {
            Achievements.TheRichGear.Unlock();
            Debug.LogWarning("Unlocked The Rich Gear");
        }
        
        if(coins == 1000000)
        {
            Achievements.TheMillionaire.Unlock();
            Debug.LogWarning("Unlocked The Millionaire");
        }
        
        if(coins == 2000000)
        {
            Achievements.TheMultiMillionaire.Unlock();
            Debug.LogWarning("Unlocked The Multi Millionaire");
        }
    }
}
