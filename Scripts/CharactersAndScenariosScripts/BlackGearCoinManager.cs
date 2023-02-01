using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackGearCoinManager : MonoBehaviour
{
    // Start is called before the first frame update
    int coins;
    public Text coinsText;

    public int coinsEarned;
    public Text coinsEarnedText;



    public static BlackGearCoinManager blackGearCoinScript;    //Dichiarazione per poter richiamare elementi di questo script da un altro

    private void Awake()
    {
        if (blackGearCoinScript == null)
        {
            blackGearCoinScript = this;
        }
    }






    // Start is called before the first frame update
    void Start()
    {
        coinsEarned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = PlayerPrefs.GetInt("coins").ToString();
        coinsEarnedText.text = coinsEarned.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {


        if (other.gameObject.tag == "coin")
        {
            //Debug.Log("Coin x1");

            coins = PlayerPrefs.GetInt("coins");
            coins += 2;
            coinsEarned += 2;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = PlayerPrefs.GetInt("coins").ToString();

        }




        if (PlayerScript.playerScript.coinFeverIsOn)
        {
            //Debug.Log("Coin x4");
            if (other.gameObject.tag == "coin")
            {
                coins = PlayerPrefs.GetInt("coins");
                coins += 8;
                coinsEarned += 8;
                PlayerPrefs.SetInt("coins", coins);
                coinsText.text = PlayerPrefs.GetInt("coins").ToString();
            }
        }




    }


}
