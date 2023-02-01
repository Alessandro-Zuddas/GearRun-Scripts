using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WorldsShopManagerScript : MonoBehaviour
{
    
    public Text coinText;

    public GameObject characterSelectionPanel;
    public GameObject startPanel;
    public GameObject worldsSelectionPanel;
    public GameObject mainPanel;
    public GameObject desertPanel;
    public GameObject snowPanel;

    public bool worldSelectionIsOn = false;

    public int currentWorldIndex = 0;

    public WorldBluePrint[] worlds;

    public Button buyButton;
    public Button selectButton;

    public AudioClip clickAudio;
    public AudioClip buyClickAudio;

    public static WorldsShopManagerScript worldsSelectionScript;

    private void Awake()
    {
        if(worldsSelectionScript == null)
        {
            worldsSelectionScript = this;
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        foreach(WorldBluePrint world in worlds)
        {
            if(world.price == 0)
            {
                world.isUnlocked = true;
            }
            else
            {
                world.isUnlocked = PlayerPrefs.GetInt(world.name, 0) == 0 ? false : true;
            }
        }

       

    }



    // Update is called once per frame
    void Update()
    {
        if (worldSelectionIsOn)
        {
            if (currentWorldIndex == 0)
            {
                mainPanel.SetActive(true);
                desertPanel.SetActive(false);
                snowPanel.SetActive(false);
            }
            else if (currentWorldIndex == 1)
            {
                mainPanel.SetActive(false);
                desertPanel.SetActive(true);
                snowPanel.SetActive(false);
            }
            else if (currentWorldIndex == 2)
            {
                mainPanel.SetActive(false);
                desertPanel.SetActive(false);
                snowPanel.SetActive(true);
            }
        }

        UpdateUI();
        coinText.text = PlayerPrefs.GetInt("coins").ToString();
    }



    public void WorldsSelectionPanelOn()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.8f);
        characterSelectionPanel.SetActive(false);
        startPanel.SetActive(false);
        worldsSelectionPanel.SetActive(true);

        CharacterShopManager.characterScript.selectionIsOn = false;
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

        if (currentWorldIndex < 2)
        {
            currentWorldIndex++;
        }
        else if(currentWorldIndex >= 2)
        {
            currentWorldIndex = 0;
        }
    }

    public void ChangePrevious()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);

        if (currentWorldIndex > 0)
        {
            currentWorldIndex--;
        }
        else if (currentWorldIndex <= 0)
        {
            currentWorldIndex = 2;
        }
    }

    public void SelectButton()
    {
        

        if (currentWorldIndex == 0)
        {
            SceneManager.LoadScene("Main");
        }
        else if(currentWorldIndex == 1)
        {
            SceneManager.LoadScene("Desert");
        }
        else if(currentWorldIndex == 2)
        {
            SceneManager.LoadScene("Snow");
        }
    }


    public void UpdateUI()
    {
        WorldBluePrint w = worlds[currentWorldIndex];

        if (w.isUnlocked)
        {
            buyButton.interactable = false;
            buyButton.GetComponentInChildren<Text>().text = "BOUGHT!";
            selectButton.interactable = true;
            

        }
        else
        {
            selectButton.interactable = false;
            buyButton.interactable = true;
            buyButton.GetComponentInChildren<Text>().text = "Buy: " + w.price;

            if (PlayerPrefs.GetInt("coins") >= w.price)
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

        WorldBluePrint w = worlds[currentWorldIndex];

        PlayerPrefs.SetInt(w.name, 1);
        w.isUnlocked = true;
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") - w.price);
    }
}
