using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    public Button iapButton;
    public bool gameSceneOn = false;
    public bool otherPlayer = false;
    public bool goldenGearOn = false;

    public bool highScorePlayed2;

    public bool doubleScoreOn;
    public bool scoreForFourIsOn;
    public bool shieldIsOn;
    public bool coinFeverIsOn;
    public bool swipeIsOn;
    public bool slideIsOn;
    



   

    
    

    public bool gameOverPlayed;
    //float moveHorizontal = Input.GetAxis("Horizontal");
    public GameObject startPanel;
    public GameObject gamePanel;
    //public Text gearText;
    //public Image gearImage;
    //public Text startText;
    public bool started;                                           //serve per tenere traccia della partenza o meno del gioco
    public bool jumping;                                           //serve per sapere se sta già saltando
    public bool adsOn;
   
    public bool gameIsOn;

    public int turn;                                               //Serve per sapere da che parte è girato il player

    public AudioClip coinSound;
    public AudioClip doubleScoreSound;
    public AudioClip scoreForFourSound;
    public AudioClip shieldSound;
    public AudioClip coinFeverSound;
    public AudioClip invincibleSound;
    public AudioClip backClickAudio;
    public AudioClip clickAudio;
    public AudioClip buyClickAudio;



    public float collHeight, collRadius, collCenterY, collCenterZ;

    public Collider capsuleCollider;

    public Rigidbody rigidBody;

    public Animator animator;

    [SerializeField]
    public float playerSpeed;

    [SerializeField]
    public float jumpForce;

    [SerializeField]
    public float directionSpeed;

    [SerializeField]
    public float moreSpeed;


    public GameObject doubleScorePanel;
    public GameObject scoreForFourPanel;
    public GameObject shieldIconPanel;
    public GameObject coinFeverPanel;
    public GameObject characterList;
   
    
    public AudioClip error;
    public Button audioButton;
    public Sprite audioOn;
    public Sprite audioOff;
    public bool audioIsOn;
    public bool goldenGearIsOn = false;

    




    public static PlayerScript playerScript;

    private void Awake()
    {
        if(playerScript == null)
        {
            playerScript = this;
        }

        
       
    }










    // Start is called before the first frame update
    void Start()
    {
        

        int adsRemove = PlayerPrefs.GetInt("adsRemover");

        if(adsRemove == 0)
        {
            Debug.Log("Estraggo Numero 1/11");
            int randNum = Random.Range(0, 11);

            if (randNum == 6)
            {
                InterstitialAd.interstitialScript.ShowAd2();
            }
        }




        //Debug.Log("Fino qui tutto bene");

        doubleScoreOn = false;
        scoreForFourIsOn = false;
        shieldIsOn = false;
        coinFeverIsOn = false;
        swipeIsOn = false;
        slideIsOn = false;
        //CoinFeverScript.coinFeverScript.enabled = false;
       
        
        

        highScorePlayed2 = false;
        gameOverPlayed = false;
        audioIsOn = true;
        audioButton.GetComponent<Image>().sprite = audioOn;

        rigidBody = GetComponent<Rigidbody>();                              //Faccio muovere il personaggio

        jumping = false;

        animator = GetComponent<Animator>();                                //Assegno alla variabile animator l'Animator del player

        started = false;

        animator.SetBool("idle", true);

        startPanel.SetActive(true);
        
        gamePanel.SetActive(false);

        doubleScorePanel.SetActive(false);
        scoreForFourPanel.SetActive(false);
        shieldIconPanel.SetActive(false);
        coinFeverPanel.SetActive(false);


        //Debug.Log("Start finito");


    }




    // Update is called once per frame
    void Update()
    {

        StartCoroutine(GameOnCoroutine());

        

    }

    







    public void Jump()
    {
        if (!jumping)
        {
            jumping = true;

            int rand = Random.Range(0, 2);

            if (rand < 1)
            {
                animator.SetTrigger("jump");
            }
            else
            {
                animator.SetTrigger("jumping");
            }                                               //Variabile trigger per impostare animazioni

            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);          //Aggiungiamo una forza di spinta verso l'alto con impulse correlativa alla massa
        }
    }

    public void TurnLeft()
    {
        rigidBody.transform.Rotate(0.0f, -90.0f, 0.0f);

        if (turn == 1)                           //A seconda della posizione in cui si trova lo faccio muovere
        {
            rigidBody.velocity = Vector3.left * playerSpeed;
            turn = 4;                           //Turn 4 verso sinistra
        }
        else if (turn == 4)
        {
            rigidBody.velocity = Vector3.back * playerSpeed;
            turn = 3;                          //Turn 3 verso giu
        }
        else if (turn == 3)
        {
            rigidBody.velocity = Vector3.right * playerSpeed;
            turn = 2;                          //Turn 2 verso destra
        }
        else if (turn == 2)
        {
            rigidBody.velocity = Vector3.forward * playerSpeed;
            turn = 1;                          //Turn 1 verso alto
        }
    }

    public void TurnRight()
    {
        rigidBody.transform.Rotate(0.0f, 90.0f, 0.0f);

        if (turn == 1)                           //A seconda della posizione in cui si trova lo faccio muovere
        {
            rigidBody.velocity = Vector3.right * playerSpeed;
            turn = 2;                           //Turn 2 verso destra
        }
        else if (turn == 2)
        {
            rigidBody.velocity = Vector3.back * playerSpeed;
            turn = 3;                          //Turn 3 verso giu
        }
        else if (turn == 3)
        {
            rigidBody.velocity = Vector3.left * playerSpeed;
            turn = 4;                          //Turn 4 verso sinistra
        }
        else if (turn == 4)
        {
            rigidBody.velocity = Vector3.forward * playerSpeed;
            turn = 1;                          //Turn 1 verso alto
        }
    }

    public void Slide()
    {
        int rand = Random.Range(0, 2);

        if (rand < 1)
        {
            animator.SetTrigger("slide");
        }
        else
        {
            animator.SetTrigger("tackle");
        }

        CapsuleCollider coll = gameObject.GetComponent<CapsuleCollider>();

        //Salvo i valori del collider per ripristinarlo più avanti
        collHeight = coll.height;
        collRadius = coll.radius;
        collCenterY = coll.center.y;
        collCenterZ = coll.center.z;

        //Modifico il capsule collider
        coll.height = 0.8f;
        coll.radius = 0.4f;
        coll.center = new Vector3(0, 0.20f, 0);

        Invoke("ExitSlide", 1.5f);
    }

    public void ExitSlide()
    {
        CapsuleCollider coll = gameObject.GetComponent<CapsuleCollider>();

        //Ripristino capsule collider all'uscita della scivolata
        coll.height = collHeight;
        coll.radius = collRadius;
        coll.center = new Vector3(0, collCenterY, collCenterZ);
    }


    public void OnTriggerEnter(Collider other)
    {
        if(!shieldIsOn)
        {
            if (other.gameObject.tag == "obstacle")
            {
                animator.SetTrigger("fall1");
                PlatformSpawnerScript.platformScript.gameOver = true;
                ScoreManagerScript.scoreScript.StopScore();
                rigidBody.constraints = RigidbodyConstraints.FreezePosition;
                scoreForFourPanel.SetActive(false);
                doubleScorePanel.SetActive(false);
                coinFeverPanel.SetActive(false);

            }
        }
        else if(shieldIsOn)
        {

            if (other.gameObject.tag == "obstacle")
            {
                
                GetComponent<AudioSource>().PlayOneShot(invincibleSound, 1f);
                
            }

        }

        if (other.gameObject.tag == "fence")
        {
            animator.SetTrigger("fall2");
            PlatformSpawnerScript.platformScript.gameOver = true;
            ScoreManagerScript.scoreScript.StopScore();
            Invoke("RigidBodyFreeze", 1f);
            scoreForFourPanel.SetActive(false);
            doubleScorePanel.SetActive(false);
            coinFeverPanel.SetActive(false);
            shieldIconPanel.SetActive(false);
        }




        if (other.gameObject.tag == "coin")              //Gestione coin
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().PlayOneShot(coinSound, 0.8f);

            
        }
        
        if(other.gameObject.tag == "coin" && coinFeverIsOn)
        {
            CoinManagerScript.coinScript.coins = PlayerPrefs.GetInt("coins");
            CoinManagerScript.coinScript.coins += 8;
            CoinManagerScript.coinScript.coinsEarned += 8;
            PlayerPrefs.SetInt("coins", CoinManagerScript.coinScript.coins);
            CoinManagerScript.coinScript.coinsText.text = PlayerPrefs.GetInt("coins").ToString();
        }

        if(other.gameObject.tag == "scorex2")           //gestione score x2
        {

            Destroy(other.gameObject);
            GetComponent<AudioSource>().PlayOneShot(doubleScoreSound, 0.5f);

            StartCoroutine(DoubleScoreCoroutine());             
        }

        if(other.gameObject.tag == "scoreX4")            //gestione score X4
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().PlayOneShot(scoreForFourSound, 0.5f);

            StartCoroutine(ScoreForFourCoroutine());
        }

        if (other.gameObject.tag == "shield")               //Gestione Invincibilità
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().PlayOneShot(shieldSound, 1f);

            StartCoroutine(ShieldActivator());
        }

        if(other.gameObject.tag == "coinFever")
        {
            Destroy(other.gameObject);
            GetComponent<AudioSource>().PlayOneShot(coinFeverSound, 1f);

            StartCoroutine(CoinFever());
        }


        if(other.gameObject.tag == "goldenGear")
        {
            StartCoroutine(GoldenGearCoroutine());
        }

      
        if(other.gameObject.tag == "swipeOn")
        {
            StartCoroutine(SwipeControlCoroutine());
        }

        if(other.gameObject.tag == "slideOn")
        {
            StartCoroutine(SlideControlCoroutine());
        }
       
       


        else if (other.gameObject.tag == "obstacle" || other.gameObject.tag == "fence" && !gameOverPlayed)  //|| other.gameObject.tag == "fence" (Da aggiungere per game overe con fences)
        {
            if(!shieldIsOn)
            {
                GetComponent<AudioSource>().PlayOneShot(error, 1f);
                gameOverPlayed = true;
            }
            
        }
    }



    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "terrain")
        {
            jumping = false;
        }
    }

    public void RigidBodyFreeze()
    {
        rigidBody.constraints = RigidbodyConstraints.FreezePosition;
    }


    public void Replay()  
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.8f);

        if (CharacterShopManager.characterScript.currentPlayerIndex == 0)
        {
            SceneManager.LoadScene("Main");
            PlayerScript.playerScript.gameSceneOn = true;
            PlayerScript.playerScript.otherPlayer = false;
        }
    }

    
    
    public void StopMusic()
    {
        if(audioIsOn)
        {
            characterList.GetComponent<AudioSource>().Stop();
            GetComponent<AudioSource>().Stop();
            audioIsOn = false;
            audioButton.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            characterList.GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().Play();
            audioIsOn = true;
            audioButton.GetComponent<Image>().sprite = audioOn;
        }
       
    }

       
    public void StartGame()
    {
        GetComponent<AudioSource>().PlayOneShot(clickAudio, 0.8f);
        gameIsOn = true;
        startPanel.SetActive(false);
    }


    IEnumerator DoubleScoreCoroutine()
    {

        doubleScorePanel.SetActive(true);
        //doubleScoreOn = true;
        ScoreManagerScript.scoreScript.normalScoreOn = false;
        
        //Debug.Log("Wait 10 seconds!/ture");

        yield return new WaitForSeconds(15);

        //doubleScoreOn = false;
        ScoreManagerScript.scoreScript.normalScoreOn = true;
        doubleScorePanel.SetActive(false);

        //Debug.Log("Wait Over!/false");
    }
    

    IEnumerator ScoreForFourCoroutine()
    {
        scoreForFourPanel.SetActive(true);
        //scoreForFourIsOn = true;
        ScoreManagerScript.scoreScript.scoreForFour = true;

        yield return new WaitForSeconds(10);

        ScoreManagerScript.scoreScript.scoreForFour = false;
        //scoreForFourIsOn = false;
        scoreForFourPanel.SetActive(false);
    }

    IEnumerator ShieldActivator()
    {
        //Debug.Log("Sei Immortale broo");
        shieldIsOn = true;
        shieldIconPanel.SetActive(true);
        

        yield return new WaitForSeconds(8);

        shieldIsOn = false;
        shieldIconPanel.SetActive(false);
        //Debug.Log("Non più broo");
    }


    IEnumerator CoinFever()
    {
        Debug.Log("Coin Fever!!!");
        coinFeverIsOn = true;
        //CoinFeverScript.coinFeverScript.enabled = true;
        coinFeverPanel.SetActive(true);

        yield return new WaitForSeconds(20);

        coinFeverIsOn = false;
        //CoinFeverScript.coinFeverScript.enabled = false;
        coinFeverPanel.SetActive(false);
        Debug.Log("Coin fever finito");
    }
  

    IEnumerator SwipeControlCoroutine()
    {
        swipeIsOn = true;

        yield return new WaitForSeconds(5);

        swipeIsOn = false;
    }


    IEnumerator SlideControlCoroutine()
    {
        Debug.Log("Slide Attivo");
        slideIsOn = true;

        yield return new WaitForSeconds(5);

        slideIsOn = false;
        Debug.Log("Slide non Attivo");
    }

    IEnumerator GoldenGearCoroutine()
    {
        //ScoreManagerScript.scoreScript.normalScoreOn = false;

        goldenGearIsOn = true;

        yield return null;
    }



    IEnumerator GameOnCoroutine()
    {
        if (!started)  //prova altrimenti rimettere originale !started
        {
            if (gameIsOn)        //prova altrimenti rimettere originale Input.GetMouseButtonDown(0)
            {
                //Debug.Log("Siamo dentro l'update");

                gamePanel.SetActive(true);



                rigidBody.velocity = Vector3.forward * playerSpeed;     //verificare



                started = true;


                turn = 1;                       //Stiamo andando verso l'alto

                PlatformSpawnerScript.platformScript.BeginToSpawn();                                                     //faccio partire spawn piattaforme

                animator.SetBool("idle", false);

                ScoreManagerScript.scoreScript.StartScore();


                //Debug.Log("Update finito");

            }
        }
        else
        {
            //Debug.Log("Siamo dentro allo swipe manager");

            if (SwipeManager.IsSwipingUp())
            {
                Jump();
            }

            if(slideIsOn)
            {
                if (SwipeManager.IsSwipingDown())
                {
                    Slide();
                }
            }

            if (swipeIsOn)
            {

                if (SwipeManager.IsSwipingLeft())
                {
                    TurnLeft();
                }

                if (SwipeManager.IsSwipingRight())
                {
                    TurnRight();
                }

            }


           
           
                float acceleration = Input.acceleration.x * directionSpeed;                 //Codice per regolare ed impostare la forza dell'inclinazione del telefono 
                transform.Translate(acceleration, 0, 0);
                Debug.Log("Turn con Gear");
           

          


            //Debug.Log("Swipe Manager finito");

        }

        if (gameIsOn)
        {
            playerSpeed = playerSpeed + moreSpeed;                          //Velocità che aumenta gradualmente

            //Debug.Log(playerSpeed);
        }

        yield return null;
    }  

    public void IapLoadScene()
    {
        SceneManager.LoadScene(18);
    }


}
