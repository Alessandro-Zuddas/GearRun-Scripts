using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharactersDesertScript : MonoBehaviour
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
            SceneManager.LoadScene("Desert");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = false;

        }

        if (CharacterShopManager.characterScript.currentPlayerIndex == 1)
        {
            SceneManager.LoadScene("Desert2");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);


        }

        if (CharacterShopManager.characterScript.currentPlayerIndex == 2)
        {
            SceneManager.LoadScene("Desert3");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);

        }


        if (CharacterShopManager.characterScript.currentPlayerIndex == 3)
        {
            SceneManager.LoadScene("Desert4");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);

        }


        if (CharacterShopManager.characterScript.currentPlayerIndex == 4)
        {
            SceneManager.LoadScene("Desert5");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;

            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);

        }


        if (CharacterShopManager.characterScript.currentPlayerIndex == 5)
        {
            SceneManager.LoadScene("Desert6");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;

            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);

        }
    }

}
