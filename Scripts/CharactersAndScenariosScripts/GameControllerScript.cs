using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(PlayerScript.playerScript.gameSceneOn)
        {

            if (!PlayerScript.playerScript.started)  //prova altrimenti rimettere originale !started
            {
                if (PlayerScript.playerScript.gameIsOn)        //prova altrimenti rimettere originale Input.GetMouseButtonDown(0)
                {
                    Debug.Log("Siamo dentro l'update");

                   PlayerScript.playerScript.gamePanel.SetActive(true);



                    PlayerScript.playerScript.rigidBody.velocity = Vector3.forward * PlayerScript.playerScript.playerSpeed;     //verificare



                    PlayerScript.playerScript.started = true;


                    PlayerScript.playerScript.turn = 1;                       //Stiamo andando verso l'alto

                    PlatformSpawnerScript.platformScript.BeginToSpawn();                                                     //faccio partire spawn piattaforme

                    PlayerScript.playerScript.animator.SetBool("idle", false);

                    ScoreManagerScript.scoreScript.StartScore();


                    Debug.Log("Update finito");

                }
            }
            else
            {
                Debug.Log("Siamo dentro allo swipe manager");

                if (SwipeManager.IsSwipingUp())
                {
                    PlayerScript.playerScript.Jump();
                }

                if (SwipeManager.IsSwipingDown())
                {
                    PlayerScript.playerScript.Slide();
                }

                if (PlayerScript.playerScript.swipeIsOn)
                {

                    if (SwipeManager.IsSwipingLeft())
                    {
                        PlayerScript.playerScript.TurnLeft();
                    }

                    if (SwipeManager.IsSwipingRight())
                    {
                        PlayerScript.playerScript.TurnRight();
                    }

                }


                float acceleration = Input.acceleration.x * PlayerScript.playerScript.directionSpeed;                 //Codice per regolare ed impostare la forza dell'inclinazione del telefono 
                transform.Translate(acceleration, 0, 0);

                Debug.Log("Swipe Manager finito");

            }

            if (PlayerScript.playerScript.gameIsOn)
            {
                PlayerScript.playerScript.playerSpeed = PlayerScript.playerScript.playerSpeed + PlayerScript.playerScript.moreSpeed;                          //Velocità che aumenta gradualmente

                //Debug.Log(playerSpeed);
            }



        }
    }
}
