using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour
{
    private string gears50 = "com.zetagamesdevelopments.gearrun.gear50k";
    private string gears250 = "com.zetagamesdevelopments.gearrun.gear250k";
    private string gears750 = "com.zetagamesdevelopments.gearrun.gear750k";
    private string gears1M = "com.zetagamesdevelopments.gearrun.gear1m";
    private string removeAds = "com.zetagamesdevelopments.gearrun.removeads";

    public GameObject purchaseOkPanel;
    public GameObject purchaseNoPanel;

    public AudioClip clickAudio;
    public AudioClip purchaseSound;
    public AudioClip purchaseNoSound;
    public Text coinsText;
    public int coins;

    public Button adsButton;


    public int adsRemover = 0;

    

    public static IAPManager iapScript;





    private void Awake()
    {
        if(iapScript == null)
        {
            iapScript = this;
        }
    }






    private void Start()
    {
       

    }

    private void Update()
    {
        coinsText.text = PlayerPrefs.GetInt("coins").ToString();
    }

    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == gears50)
        {
            //Aggiungi 50k Gear al Player
            GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);
            coins = PlayerPrefs.GetInt("coins");
            coins += 50000;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = PlayerPrefs.GetInt("coins").ToString();
            GetComponent<AudioSource>().PlayOneShot(purchaseSound, 0.5f);


            Debug.Log("Acquisto di 50k");
            purchaseOkPanel.SetActive(true);
            purchaseNoPanel.SetActive(false);
        }

        if (product.definition.id == gears250)
        {
            //Aggiungi 250k Gear al Player
            GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);
            coins = PlayerPrefs.GetInt("coins");
            coins += 250000;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = PlayerPrefs.GetInt("coins").ToString();
            GetComponent<AudioSource>().PlayOneShot(purchaseSound, 0.5f);


            Debug.Log("Acquisto di 250k");
            purchaseOkPanel.SetActive(true);
            purchaseNoPanel.SetActive(false);
        }

        if (product.definition.id == gears750)
        {
            //Aggiungi 750k Gear al Player
            GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);
            coins = PlayerPrefs.GetInt("coins");
            coins += 750000;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = PlayerPrefs.GetInt("coins").ToString();
            GetComponent<AudioSource>().PlayOneShot(purchaseSound, 0.5f);


            Debug.Log("Acquisto di 750k");
            purchaseOkPanel.SetActive(true);
            purchaseNoPanel.SetActive(false);
        }

        if (product.definition.id == gears1M)
        {
            //Aggiungi 1.5M Gear al Player
            GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);
            coins = PlayerPrefs.GetInt("coins");
            coins += 1500000;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = PlayerPrefs.GetInt("coins").ToString();
            GetComponent<AudioSource>().PlayOneShot(purchaseSound, 0.5f);


            Debug.Log("Acquisto di 1.5M");
            purchaseOkPanel.SetActive(true);
            purchaseNoPanel.SetActive(false);
        }

        if (product.definition.id == removeAds)
        {
            //Rimuovi Interstitial Ads
            Debug.Log("Ads rimossi");
            PlayerPrefs.SetInt("adsRemover", 1);
           



            adsButton.enabled = false;
            purchaseOkPanel.SetActive(true);
            purchaseNoPanel.SetActive(false);
            GetComponent<AudioSource>().PlayOneShot(purchaseSound, 0.5f);
        }

    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        //Fai uscire pannello con transazione negata
        Debug.Log(product.definition.id + "failed because" + failureReason);
        GetComponent<AudioSource>().PlayOneShot(purchaseNoSound, 0.5f);

        purchaseNoPanel.SetActive(true);
        purchaseOkPanel.SetActive(false);
    }

  
}
