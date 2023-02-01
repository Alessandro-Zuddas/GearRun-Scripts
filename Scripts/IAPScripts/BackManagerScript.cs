using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackManagerScript : MonoBehaviour
{
    public GameObject purchaseOkPanel;
    public GameObject purchaseNoPanel;
    public AudioClip clickAudio;

    // Start is called before the first frame update
    void Start()
    {
        purchaseNoPanel.SetActive(false);
        purchaseOkPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        if(WorldsShopManagerScript.worldsSelectionScript.currentWorldIndex == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);
            SceneManager.LoadScene("Main");
        }

        if(WorldsShopManagerScript.worldsSelectionScript.currentWorldIndex == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);
            SceneManager.LoadScene("Desert");
        }

        if(WorldsShopManagerScript.worldsSelectionScript.currentWorldIndex == 2)
        {
            GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);
            SceneManager.LoadScene("Snow");
        }
    }

    public void ClosePurchasePanel()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);
        purchaseOkPanel.SetActive(false);
    }

    public void ClosePurchasePanel2()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.5f);
        purchaseNoPanel.SetActive(false);
    }
}
