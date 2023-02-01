using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterListScript : MonoBehaviour
{
    private GameObject[] characterList;
    public int index;

    public GameObject player;
    public GameObject characterSelectionPanel;
    public GameObject startPanel;

    public Text coinText;

    public bool selectionIsOn = false;

    public static CharacterListScript characterScript;

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
        index = PlayerPrefs.GetInt("choice", index);


        if(selectionIsOn)
        {
            CameraScript.cameraScript.enabled = false;
            
        }

        


        characterList = new GameObject[transform.childCount];

        //Riempio l'array con i modelli
        for(int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        //Disatti o personaggi che non uso
        foreach(GameObject go in characterList)
        {
            go.SetActive(false);
        }

        //ABILITO PERSONAGGIO CORRENTE

        if(characterList[index])
        {
            characterList[index].SetActive(true);
        }

        coinText.text = PlayerPrefs.GetInt("coins").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(selectionIsOn)
        {
            startPanel.SetActive(false);
        }
    }

    public void CharacterSelectionPanelOn()
    {
        CameraScript.cameraScript.enabled = false;
        startPanel.SetActive(false);
        characterSelectionPanel.SetActive(true);
        player.transform.Rotate(transform.rotation.x, transform.rotation.y + 180f, transform.rotation.z);
    }

    public void CharacterSelectionPanelOff()
    {
        characterSelectionPanel.SetActive(false); 
        startPanel.SetActive(true);
        player.transform.Rotate(transform.rotation.x, transform.rotation.y - 180f, transform.rotation.z);
        selectionIsOn = true;
    }


    public void ToggleLeft()
    {
        //Toggle off the current model
        characterList[index].SetActive(false);

        index--;
        if(index < 0)
        {
            index = characterList.Length - 1;
        }

        //Toggle on the new model

        characterList[index].SetActive(true);

    }

    public void ToggleRight()
    {
        //Toggle off the current model
        characterList[index].SetActive(false);

        index++;
        if (index == characterList.Length)
        {
            index = 0;
        }

        //Toggle on the new model

        characterList[index].SetActive(true);

    }

    public void SelectButton()
    {
        PlayerPrefs.SetInt("choice", index);
        SceneManager.LoadScene("Main");
    }
}
