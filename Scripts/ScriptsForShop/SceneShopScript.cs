using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneShopScript : MonoBehaviour
{

    public int currentWorldIndex = 0;
    public GameObject[] worldsPanels;


    public static SceneShopScript sceneShopScript;

    private void Awake()
    {
        if(sceneShopScript == null)
        {
            sceneShopScript = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject world in worldsPanels)
        {
            if(CharacterShopManager.characterScript.worldSelectionIsOn)
            {
                world.SetActive(false);

                worldsPanels[currentWorldIndex].SetActive(true);
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
