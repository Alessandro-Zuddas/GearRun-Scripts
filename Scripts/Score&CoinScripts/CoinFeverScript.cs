using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinFeverScript : MonoBehaviour
{
    int coins;
    public Text coinsText;

    public int coinsEarned;
    public Text coinsEarnedText;

    public static CoinFeverScript coinFeverScript;

    private void Awake()
    {
        if(coinFeverScript == null)
        {
            coinFeverScript = this;
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
        if (PlayerScript.playerScript.coinFeverIsOn)
        {
            //Debug.Log("Coin x4");
            if (other.gameObject.tag == "coin")
            {
                coins = PlayerPrefs.GetInt("coins");
                coins += 20;
                coinsEarned += 20;
                PlayerPrefs.SetInt("coins", coins);
                coinsText.text = PlayerPrefs.GetInt("coins").ToString();
            }
        }
    }
}
