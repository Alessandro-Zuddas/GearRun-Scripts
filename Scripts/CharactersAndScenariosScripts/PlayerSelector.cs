using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public int currentPlayerIndex;
    public GameObject[] players;



    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject player in players)
        {
            currentPlayerIndex = PlayerPrefs.GetInt("SelectedPlayer", 0);
            player.SetActive(false);

            players[currentPlayerIndex].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
