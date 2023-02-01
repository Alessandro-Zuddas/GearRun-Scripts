using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesertReloader5 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerScript.playerScript.gameIsOn)
        {

            if (PlayerScript.playerScript.otherPlayer == false)
            {
                float acceleration = Input.acceleration.x * PlayerScript.playerScript.directionSpeed;                 //Codice per regolare ed impostare la forza dell'inclinazione del telefono 
                transform.Translate(acceleration, 0, 0);
                //Debug.Log("Turn con Gear");
            }

            if (PlayerScript.playerScript.otherPlayer == true)
            {
                float acceleration2 = Input.acceleration.x - PlayerScript.playerScript.directionSpeed;               //Codice per regolare ed impostare la forza dell'inclinazione del telefono 
                transform.Translate(acceleration2, 0, 0);
                //Debug.Log("Turn con other");
            }
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("Desert5");
        PlayerScript.playerScript.otherPlayer = true;
    }

}