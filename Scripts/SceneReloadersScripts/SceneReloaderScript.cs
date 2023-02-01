using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloaderScript : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Reload()
    {
        SceneManager.LoadScene("Main2");
        PlayerScript.playerScript.otherPlayer = true;
    }
}
