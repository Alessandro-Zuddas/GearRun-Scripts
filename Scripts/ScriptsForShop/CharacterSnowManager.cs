using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSnowManager : MonoBehaviour
{
    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SelectButton()
    {
        if (CharacterShopManager.characterScript.currentPlayerIndex == 0)
        {
            SceneManager.LoadScene("Snow");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = false;

        }

        if (CharacterShopManager.characterScript.currentPlayerIndex == 1)
        {
            SceneManager.LoadScene("Snow2");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);


        }

        if (CharacterShopManager.characterScript.currentPlayerIndex == 2)
        {
            SceneManager.LoadScene("Snow3");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);

        }


        if (CharacterShopManager.characterScript.currentPlayerIndex == 3)
        {
            SceneManager.LoadScene("Snow4");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);

        }


        if (CharacterShopManager.characterScript.currentPlayerIndex == 4)
        {
            SceneManager.LoadScene("Snow5");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;

            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);

        }


        if (CharacterShopManager.characterScript.currentPlayerIndex == 5)
        {
            SceneManager.LoadScene("Snow6");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;

            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);

        }
    }

}