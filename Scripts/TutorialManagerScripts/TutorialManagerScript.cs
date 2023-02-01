using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManagerScript : MonoBehaviour
{
    public bool isFirstGame = true;


    public GameObject tutorialPanel1;
    public GameObject tutorialPanel2;
    public GameObject tutorialPanel3;
    public GameObject startPanel;
    public GameObject selectionPanel;
    public GameObject worldsSelectionPanel;

    public AudioClip clickAudio;
 


    private void Start()
    {
        StartTutorialPanels();
    }



    private void StartTutorialPanels()
    {
        if (isFirstGame)
        {
            //Debug.Log("Tutorial");
            tutorialPanel1.SetActive(true);
            tutorialPanel2.SetActive(true);
            tutorialPanel3.SetActive(true);
            SetFirstGameFalse();
        }
        
        if (!isFirstGame)
        {
           // Debug.Log("Niente Tutorial");
            tutorialPanel1.SetActive(false);
            tutorialPanel2.SetActive(false);
            tutorialPanel3.SetActive(false);
        }
    }
   

    public void CloseTutorial1()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.8f);
        tutorialPanel1.SetActive(false);
    }

    public void CloseTutorial2()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.8f);
        tutorialPanel2.SetActive(false);
    }

    public void CloseTutorial3()
    {
        tutorialPanel3.SetActive(false);
        startPanel.SetActive(true);
        ReturnToMenu();
    }

    void SetFirstGameFalse()
    {
        isFirstGame = false;
    }

    public void TutorialButton()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.8f);
        startPanel.SetActive(false);
        selectionPanel.SetActive(false);
        worldsSelectionPanel.SetActive(false);
        tutorialPanel1.SetActive(true);
        tutorialPanel2.SetActive(true);
        tutorialPanel3.SetActive(true);
    }


    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Main");
    }

    public void ReturnToMenu2()
    {
        SceneManager.LoadScene("Desert");
    }

    public void ReturnToMenu3()
    {
        SceneManager.LoadScene("Snow");
    }
}
