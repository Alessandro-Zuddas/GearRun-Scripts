using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class CharacterShopManager : MonoBehaviour
{
    public Image lockImage;
    public float rotationSpeed = 15f;
    public bool mainSceneOn = false;
    public bool selectionIsOn = false;
    public GameObject player;
    public GameObject startPanel;
    public GameObject characterSelectionPanel;
    public GameObject worldsSelectionPanel;
    public Text coinText;

    public int currentPlayerIndex;
    public GameObject[] playerModels;

    public GearBlueprint[] players;
    public Button buyButton;
    public Button selectButton;

    public bool isGoldGear = false;
    public bool worldSelectionIsOn = false;


    public bool gearOn;
    public bool blueGearOn;
    public bool greenGearOn;
    public bool turquoiseGearOn;
    public bool blackGearOn;
    public bool goldGearOn;

    public static CharacterShopManager characterScript;

    public AudioClip clickAudio;
    public AudioClip buyClickAudio;
    


    private void Awake()
    {
        if(characterScript == null)
        {
            characterScript = this;
        }
    }




    // Start is called before the first frame update
    void Start()
    {

        

        if (selectionIsOn)
        {
            CameraScript.cameraScript.enabled = false;

        }

        foreach (GameObject player in playerModels)
        {
           // currentPlayerIndex = PlayerPrefs.GetInt("SelectedPlayer", 0);
            player.SetActive(false);

            playerModels[currentPlayerIndex].SetActive(true);
        }

        foreach(GearBlueprint player in players)
        {
            if(player.price == 0)
            {
                player.isUnlocked = true;
            }
            else
            {
                player.isUnlocked = PlayerPrefs.GetInt(player.name, 0)== 0 ? false : true;
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
       if(mainSceneOn)
        {
            currentPlayerIndex = 0;
        }


       if(currentPlayerIndex == 0)
        {
            gearOn = true;
            blueGearOn = false;
            greenGearOn = false;
            turquoiseGearOn = false;
            blackGearOn = false;
            goldGearOn = false;
        }
       else if(currentPlayerIndex == 1)
        {
            gearOn = false;
            blueGearOn = true;
            greenGearOn = false;
            turquoiseGearOn = false;
            blackGearOn = false;
            goldGearOn = false;
        }
       else if(currentPlayerIndex == 2)
        {
            gearOn = false;
            blueGearOn = false;
            greenGearOn = true;
            turquoiseGearOn = false;
            blackGearOn = false;
            goldGearOn = false;
        }
       else if(currentPlayerIndex == 3)
        {
            gearOn = false;
            blueGearOn = false;
            greenGearOn = false;
            turquoiseGearOn = true;
            blackGearOn = false;
            goldGearOn = false;
        }
       else if(currentPlayerIndex == 4)
        {
            gearOn = false;
            blueGearOn = false;
            greenGearOn = false;
            turquoiseGearOn = false;
            blackGearOn = true;
            goldGearOn = false;
        }
       else if(currentPlayerIndex == 5)
        {
            gearOn = false;
            blueGearOn = false;
            greenGearOn = false;
            turquoiseGearOn = false;
            blackGearOn = false;
            goldGearOn = true;
        }

        UpdateUI();
        coinText.text = PlayerPrefs.GetInt("coins").ToString();

    }


    public void CharacterSelectionPanelOn()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.8f);
        CameraScript.cameraScript.enabled = false;
        startPanel.SetActive(false);
        worldsSelectionPanel.SetActive(false);
        characterSelectionPanel.SetActive(true);
        player.transform.Rotate(transform.rotation.x, transform.rotation.y + 180f, transform.rotation.z);
       

    }

    public void CharacterSelectionPanelOff()
    {
        characterSelectionPanel.SetActive(false);
        startPanel.SetActive(true);
        player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);
       
        selectionIsOn = false; 
    }


    public void WorldsSelectionPanelOn()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);

        characterSelectionPanel.SetActive(false);
        startPanel.SetActive(false);
        worldsSelectionPanel.SetActive(true);

        selectionIsOn = false;
        worldSelectionIsOn = true;

    }

    public void WorldsSelectionPanelOff()
    {

        worldsSelectionPanel.SetActive(false);
        startPanel.SetActive(true);

        worldSelectionIsOn = false;
    }



    public void ChangeNext()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.8f);

        playerModels[currentPlayerIndex].SetActive(false);

        currentPlayerIndex++;

        if(currentPlayerIndex == playerModels.Length)
        {
            currentPlayerIndex = 0;
        }

        playerModels[currentPlayerIndex].SetActive(true);
        //PlayerPrefs.SetInt("SelectedPlayer", currentPlayerIndex);


    }


    public void ChangePrevious()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.8f);

        playerModels[currentPlayerIndex].SetActive(false);

        currentPlayerIndex--;

        if (currentPlayerIndex == -1)
        {
            currentPlayerIndex = playerModels.Length -1;
        }

        playerModels[currentPlayerIndex].SetActive(true);
        //PlayerPrefs.SetInt("SelectedPlayer", currentPlayerIndex);


    }

    public void SelectButton()
    {
       if(currentPlayerIndex == 0)
        {
            SceneManager.LoadScene("Main");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = false;
           
        }

       if(currentPlayerIndex == 1)
        {
            SceneManager.LoadScene("Main2");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);
           

        }

        if (currentPlayerIndex == 2)
        {
            SceneManager.LoadScene("Main3");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);
           
        }


        if (currentPlayerIndex == 3)
        {
            SceneManager.LoadScene("Main4");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);
           
        }


        if (currentPlayerIndex == 4)
        {
            SceneManager.LoadScene("Main5");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
           
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);
           
        }


        if (currentPlayerIndex == 5)
        {
            SceneManager.LoadScene("Main6");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = true;
            
            player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);
           
        }
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
        mainSceneOn = true;
        PlayerScript.playerScript.otherPlayer = false;
    }

    public void BackToDesert()
    {
        SceneManager.LoadScene("Desert");
        mainSceneOn = true;
        PlayerScript.playerScript.otherPlayer = false;
    }

    public void BackToSnow()
    {
        SceneManager.LoadScene("Snow"); 
        mainSceneOn = true;
        PlayerScript.playerScript.otherPlayer = false;
    }

    public void UpdateUI()
    {
        GearBlueprint p = players[currentPlayerIndex];

        if(p.isUnlocked)
        {
            buyButton.interactable = false;
            buyButton.GetComponentInChildren<Text>().text = "BOUGHT!";
            selectButton.interactable = true;
            
            
        }
        else
        {
            selectButton.interactable = false;
            buyButton.interactable = true;
            buyButton.GetComponentInChildren<Text>().text = "Buy: " + p.price;

            if (PlayerPrefs.GetInt("coins") >= p.price)
            {
                selectButton.interactable = false;
                buyButton.interactable = true;
            }
            else
            {
                selectButton.interactable = false;
                buyButton.interactable = false;
            }
        }
    }

    public void UnlockPlayer()
    {
        GetComponent<AudioSource>().PlayOneShot(buyClickAudio, 0.8f);

        GearBlueprint p = players[currentPlayerIndex];

        PlayerPrefs.SetInt(p.name, 1);
        p.isUnlocked = true;
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - p.price);
    }
}
