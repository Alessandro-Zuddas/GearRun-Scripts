using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAd : MonoBehaviour
{
    

    public static InterstitialAd interstitialScript;

    private void Awake()
    {
        if(interstitialScript == null)
        {
            interstitialScript = this;
        }
    }


    private string game_id = "4679515";
    private static string video_ad = "Interstitial_Android";

    void Start()
    {
        Advertisement.Initialize(game_id, false); //test mode  false true


        UnityEngine.Advertisements.MetaData metaData = new UnityEngine.Advertisements.MetaData("privacy");
        metaData.Set("mode", "mixed"); // This is a mixed audience game.
        Advertisement.SetMetaData(metaData);

        UnityEngine.Advertisements.MetaData userMetaData = new UnityEngine.Advertisements.MetaData("user");
        userMetaData.Set("nonbehavioral", "true"); // This user will NOT receive personalized ads.
        Advertisement.SetMetaData(userMetaData);
        
    }

    public static void ShowAd()
    {
        if (Advertisement.IsReady(video_ad))
        {
            Advertisement.Show(video_ad);
            Advertisement.Banner.Hide();
        }
    }

    public void ShowAd2()
    {
        if (Advertisement.IsReady(video_ad))
        {
            Debug.Log("Ads Attivi!");
            Advertisement.Show(video_ad);
            Advertisement.Banner.Hide();
        }
    }

  
}
