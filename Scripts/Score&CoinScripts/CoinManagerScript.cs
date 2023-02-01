using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManagerScript : MonoBehaviour
{
    public int coins;
    public Text coinsText;


    
    public int coinsEarned;
    public Text coinsEarnedText;

    //public bool coinFeverIsOn;

    public static CoinManagerScript coinScript;    //Dichiarazione per poter richiamare elementi di questo script da un altro

    private void Awake()
    {
        if(coinScript == null)
        {
            coinScript = this;
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
            coins += 1;
            coinsEarned += 1;
            PlayerPrefs.SetInt("coins", coins);
            coinsText.text = PlayerPrefs.GetInt("coins").ToString();

           
        }


     

    }


   
}
