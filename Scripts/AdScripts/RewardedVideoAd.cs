using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;
using UnityEngine.UI;

public class RewardedVideoAd : MonoBehaviour
{
    public GameObject rewardPanel;

    public int coins;

    public AudioClip purchaseSound;
    public AudioClip clickAudio;

    private string game_id = "4679515";
    private static string rewardedVideo_ad = "Rewarded_Android";

    private static RewardedVideoAd instance;

    void Start()
    {
        Monetization.Initialize(game_id, false);    //test mode
        instance = this;


        UnityEngine.Advertisements.MetaData metaData = new UnityEngine.Advertisements.MetaData("privacy");
        metaData.Set("mode", "mixed"); // This is a mixed audience game.
        Advertisement.SetMetaData(metaData);

        UnityEngine.Advertisements.MetaData userMetaData = new UnityEngine.Advertisements.MetaData("user");
        userMetaData.Set("nonbehavioral", "true"); // This user will NOT receive personalized ads.
        Advertisement.SetMetaData(userMetaData);
    }

    public static void ShowAd()
    {
        instance.StartCoroutine(instance.WaitForAd());
    }

    IEnumerator WaitForAd()
    {
        while (!Monetization.IsReady(rewardedVideo_ad))
        {
            yield return null;
        }

        ShowAdPlacementContent ad = null;
        ad = Monetization.GetPlacementContent(rewardedVideo_ad) as ShowAdPlacementContent;

        if (ad != null)
        {
            ad.Show(AdFinished);
        }
    }

    void AdFinished(UnityEngine.Monetization.ShowResult result)
    {
        if (result == UnityEngine.Monetization.ShowResult.Finished)
        {
            // REWARD HERE
            rewardPanel.SetActive(true);

            coins = PlayerPrefs.GetInt("coins");
            coins += 1000;
            PlayerPrefs.SetInt("coins", coins);
            GetComponent<AudioSource>().PlayOneShot(purchaseSound, 0.5f);
        }
        else
        {
            // VIDEO WAS SKIPPPED
            Debug.Log("Skipped");
        }
    }

    public void CloseFreeCoinsPanel()
    {
        rewardPanel.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);
    }
}
