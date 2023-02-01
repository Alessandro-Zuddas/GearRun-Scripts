using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagerScript : MonoBehaviour
{
    public AudioClip clickAudio;

    public GameObject gearPanel;
    public GameObject blueGearPanel;
    public GameObject greenGearPanel;
    public GameObject turquoiseGearPanel;
    public GameObject blackGearPanel;
    public GameObject goldGearPanel;

    // Start is called before the first frame update
    void Start()
    {
        gearPanel.SetActive(false);
        blueGearPanel.SetActive(false);
        greenGearPanel.SetActive(false);
        turquoiseGearPanel.SetActive(false);
        blackGearPanel.SetActive(false);
        goldGearPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if(CharacterShopManager.characterScript.gearOn)
      {
            gearPanel.SetActive(true);
            blueGearPanel.SetActive(false);
            greenGearPanel.SetActive(false);
            turquoiseGearPanel.SetActive(false);
            blackGearPanel.SetActive(false);
            goldGearPanel.SetActive(false);
        }

      if(CharacterShopManager.characterScript.blueGearOn)
      {
            gearPanel.SetActive(false);
            blueGearPanel.SetActive(true);
            greenGearPanel.SetActive(false);
            turquoiseGearPanel.SetActive(false);
            blackGearPanel.SetActive(false);
            goldGearPanel.SetActive(false);
        }

      if (CharacterShopManager.characterScript.greenGearOn)
      {
            gearPanel.SetActive(false);
            blueGearPanel.SetActive(false);
            greenGearPanel.SetActive(true);
            turquoiseGearPanel.SetActive(false);
            blackGearPanel.SetActive(false);
            goldGearPanel.SetActive(false);
        }

      if (CharacterShopManager.characterScript.turquoiseGearOn)
      {

            gearPanel.SetActive(false);
            blueGearPanel.SetActive(false);
            greenGearPanel.SetActive(false);
            turquoiseGearPanel.SetActive(true);
            blackGearPanel.SetActive(false);
            goldGearPanel.SetActive(false);
        }

      if (CharacterShopManager.characterScript.blackGearOn)
      {
            gearPanel.SetActive(false);
            blueGearPanel.SetActive(false);
            greenGearPanel.SetActive(false);
            turquoiseGearPanel.SetActive(false);
            blackGearPanel.SetActive(true);
            goldGearPanel.SetActive(false);
        }

      if(CharacterShopManager.characterScript.goldGearOn)
      {
            gearPanel.SetActive(false);
            blueGearPanel.SetActive(false);
            greenGearPanel.SetActive(false);
            turquoiseGearPanel.SetActive(false);
            blackGearPanel.SetActive(false);
            goldGearPanel.SetActive(true);
      }
    }
}
