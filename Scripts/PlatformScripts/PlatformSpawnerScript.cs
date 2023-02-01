using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerScript : MonoBehaviour
{
    public GameObject platform, corner1, corner2, corner3, corner4;
    public bool gameOver;
    Vector3 lastPos;                                             //Posizione ultima piattaforma inserita
    float size, sizeCorner;                                                  //Lunghezza effettiva piattaforma
    int direction;                                               //Direzione attuale piattaforma
    private int counterUp;                                       //Numero di piattaforme da creare
    private int counterHor;                                      //Numero piattaforme orizzontali da creare
    float timeForCreation = 0.8f;                                //tempo di attesa prima di creare una nuova piattaforma
    public GameObject coin;
    public static PlatformSpawnerScript platformScript;                 //Dichiarazione per poter richiamare elementi di questo script da un altro
    public GameObject doubleScorePowerUp;
    public GameObject scoreForFourPowerUp;
    public GameObject shieldPowerUp;
    public GameObject coinFeverPowerUp;



    private void Awake()
    {
        if(platformScript == null)
        {
            platformScript = this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        gameOver = true;

        direction = 1;                                          //Up

        lastPos = new Vector3(platform.transform.position.x, platform.transform.position.y, platform.transform.position.z - 0.2f);

        Bounds momSize = GetMaxBounds(platform);

        size = momSize.size.z;                                    //Prendo l'asse z di momSize

        counterUp = 5;                                          //Numero di piattaforme iniziali

        InvokeRepeating("SpawnInitialVertical", 0.1f, 0.1f);      //Richiama la void ripetutamente il metodo SpawnInitialVertical e ripete la chiamata ogni 0.1 secondi

    }

    // Update is called once per frame
    void Update()
    {
       
        
    }


    void CreateCoins(Vector3 pos)
    {
      
            int rand = Random.Range(0, 2);  //Alzare o abbassare per frequenza spawn coins

            if (rand <= 1)
            {
                Instantiate(coin, new Vector3(pos.x, pos.y + 1.2f, pos.z), coin.transform.rotation);
            }
      
    }

    void CreatePowerUps(Vector3 pos)
    {
        int rand = Random.Range(0, 400);  //Alzare o abbassare per frequenza spawn power ups

        if (rand >= 0 && rand <= 10 )  //Probabilità double score
        {
            Instantiate(doubleScorePowerUp, new Vector3(pos.x, pos.y + 1.2f, pos.z + 1f), doubleScorePowerUp.transform.rotation);
        }

        if (rand >= 100 && rand <= 107)  //Probabilità scoreForFour
        {
            Instantiate(scoreForFourPowerUp, new Vector3(pos.x, pos.y + 1.2f, pos.z - 1f), scoreForFourPowerUp.transform.rotation);
        }

        if(rand >= 200 && rand <= 206) //Probabilità scudo
        {
            Instantiate(shieldPowerUp, new Vector3(pos.x, pos.y + 1.2f, pos.z), shieldPowerUp.transform.rotation);
        }

        if(rand >= 300 && rand <= 306) //Probabilità Coin Fever
        {
            Instantiate(coinFeverPowerUp, new Vector3(pos.x, pos.y + 1.2f, pos.z), coinFeverPowerUp.transform.rotation);
        }


    }


    void SpawnInitialVertical()
      {
        Vector3 pos = lastPos;
        pos.z += size;

        lastPos = new Vector3(pos.x, pos.y, pos.z - 0.2f);

        GameObject newObject = GroundVerticalPoolerScript.poolScript.GetPooledObject();

        if(newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.identity;
        newObject.SetActive(true);
        CreateCoins(pos);                           //Da mettere in tutte le piattaforme in cui c'è lo spawn per spawnare i coins
        CreatePowerUps(pos);

        if (--counterUp <= 0)
        {
            CancelInvoke("SpawnInitialVertical");
        }

      }




    public void BeginToSpawn()
    {
        direction = 1;          //up

        gameOver = false;

        Bounds momSize = GetMaxBounds(platform);

        size = momSize.size.z;

        momSize = GetMaxBounds(corner1);

        sizeCorner = momSize.size.z;

        counterUp = 1;

        InvokeRepeating("SpawnVertical", 0.1f, timeForCreation);
    }

    
    void SpawnVertical()
    {
        Vector3 pos = lastPos;
        pos.z += size;

        lastPos = new Vector3(pos.x, pos.y, pos.z - 0.2f);

        GameObject newObject = GroundVerticalPoolerScript.poolScript.GetPooledObject();

        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.identity;
        newObject.SetActive(true);

        if (--counterUp <= 0)
        {
            CancelInvoke("SpawnVertical");

            if(!gameOver)
            {
                CreateCombinations();
                SpawnCornersHorizontal();
            }
        }
    }




    Bounds GetMaxBounds(GameObject g)
    {
        var b = new Bounds(g.transform.position, Vector3.zero);         //V3.zero == V3(0,0,0)

        foreach(Renderer r in g.GetComponentsInChildren<Renderer>())
        {
            b.Encapsulate(r.bounds);
        }
        return b;
    }


    void SpawnObstacleVertical(GameObject newObj)                                            //Serve per le situazioni che si vogliono creare dovendo solo usare questo metodo e dichiarare il gameobject che si intende usare
    {
        Vector3 pos = lastPos;                                                                //Questa void lavora con un oggetto passato come argomento dagli altri pooler per poi andarlo a lavorare e settarlo randomicamente a seconda del risultato dell'estrazione sulle piattaforme spawnate
        pos.z += size;

        lastPos = new Vector3(pos.x, pos.y, pos.z - 0.2f);


        if (newObj == null)
        {
            return;
        }

        newObj.transform.position = pos;
        newObj.transform.rotation = Quaternion.identity;
        newObj.SetActive(true);
        CreateCoins(pos);
        CreatePowerUps(pos);

        //Metto una piattaforma normale

        pos = lastPos;                                                                //Questa void lavora con un oggetto passato come argomento dagli altri pooler per poi andarlo a lavorare e settarlo randomicamente a seconda del risultato dell'estrazione sulle piattaforme spawnate
        pos.z += size;

        lastPos = new Vector3(pos.x, pos.y, pos.z - 0.2f);

        newObj = GroundVerticalPoolerScript.poolScript.GetPooledObject();

        if (newObj == null)
        {
            return;
        }

        newObj.transform.position = pos;
        newObj.transform.rotation = Quaternion.identity;
        newObj.SetActive(true);


    }



    void CreateCombinations()                                   //Gestione spawn piattaforme
    {
        SpawnInitialVertical();
        SpawnInitialVertical();

        int rand = Random.Range(0, 30);

        //0 o 1
        if(rand >= 0 && rand < 2)
        {
            //Ostacolo 1 
            SpawnObstacleVertical(GroundVerticalObstacle1PoolerScript.obstacle1Script.GetPooledObject());

            //Ostacolo 2
            SpawnObstacleVertical(GroundVerticalObstacle2PoolerScript.obstacle2Script.GetPooledObject());
        }

        //2 o 3
        if(rand > 1 && rand < 4)
        {
            //ostacolo 3
            SpawnObstacleVertical(GroundVerticalObstacle3PoolerScript.obstacle3Script.GetPooledObject());

            //ostacolo 6
            SpawnObstacleVertical(GroundVerticalObstacle6PoolerScript.obstacle6Script.GetPooledObject());
        }

        //4 o 5
        if(rand > 3 && rand < 6)
        {
            //ostacolo 5
            SpawnObstacleVertical(GroundVerticalObstacle5PoolerScript.obstacle5Script.GetPooledObject());

            //ostacolo 6
            SpawnObstacleVertical(GroundVerticalObstacle6PoolerScript.obstacle6Script.GetPooledObject());
        }

        //6 o 7
        if(rand > 5 && rand < 8)
        {
            //Ostacolo 2
            SpawnObstacleVertical(GroundVerticalObstacle2PoolerScript.obstacle2Script.GetPooledObject());

            //Ostacolo 1
            SpawnObstacleVertical(GroundVerticalObstacle1PoolerScript.obstacle1Script.GetPooledObject());
        }

        //8 o 9
        if(rand > 7 && rand < 10)
        {
            //ostacolo 5
            SpawnObstacleVertical(GroundVerticalObstacle5PoolerScript.obstacle5Script.GetPooledObject());

            //Ostacolo 2
            SpawnObstacleVertical(GroundVerticalObstacle2PoolerScript.obstacle2Script.GetPooledObject());
        }


        //10 o 11
        if (rand > 9 && rand < 12)
        {
            //ostacolo 5
            SpawnObstacleVertical(GroundVerticalObstacle5PoolerScript.obstacle5Script.GetPooledObject());

            //Ostacolo 1
            SpawnObstacleVertical(GroundVerticalObstacle1PoolerScript.obstacle1Script.GetPooledObject());
        }

        //12 o 13
        if (rand > 11 && rand < 14)
        {
            //Ostacolo 3 
            SpawnObstacleVertical(GroundVerticalObstacle3PoolerScript.obstacle3Script.GetPooledObject());

            //Ostacolo 2
            SpawnObstacleVertical(GroundVerticalObstacle2PoolerScript.obstacle2Script.GetPooledObject());
        }

        //14 o 15
        if (rand > 13 && rand < 16)
        {
            //Ostacolo 3 
            SpawnObstacleVertical(GroundVerticalObstacle3PoolerScript.obstacle3Script.GetPooledObject());

            //Ostacolo 1
            SpawnObstacleVertical(GroundVerticalObstacle1PoolerScript.obstacle1Script.GetPooledObject());
        }

        //16 o 17
        if (rand > 15 && rand < 18)
        {
            //Ostacolo 3 
            SpawnObstacleVertical(GroundVerticalObstacle3PoolerScript.obstacle3Script.GetPooledObject());

            //ostacolo 6
            SpawnObstacleVertical(GroundVerticalObstacle6PoolerScript.obstacle6Script.GetPooledObject());
        }

        //18 o 19
        if (rand > 17 && rand < 20)
        {
            //ostacolo 6
            SpawnObstacleVertical(GroundVerticalObstacle6PoolerScript.obstacle6Script.GetPooledObject());

            //ostacolo 5
            SpawnObstacleVertical(GroundVerticalObstacle5PoolerScript.obstacle5Script.GetPooledObject());
        }

        //20 o 21
        if(rand > 19 && rand < 22)
        {
            //ostacolo 4
            SpawnObstacleVertical(GroundVerticalObstacle4PoolerScript.obstacle4Script.GetPooledObject());


            //Ostacolo 1
            SpawnObstacleVertical(GroundVerticalObstacle1PoolerScript.obstacle1Script.GetPooledObject());
        }

        //22 o 23
        if (rand > 21 && rand < 24)
        {
            //ostacolo 4
            SpawnObstacleVertical(GroundVerticalObstacle4PoolerScript.obstacle4Script.GetPooledObject());


            //Ostacolo 2
            SpawnObstacleVertical(GroundVerticalObstacle2PoolerScript.obstacle2Script.GetPooledObject());
        }

        //24 o 25
        if (rand > 23 && rand < 26)
        {
            //ostacolo 4
            SpawnObstacleVertical(GroundVerticalObstacle4PoolerScript.obstacle4Script.GetPooledObject());


            //ostacolo 6
            SpawnObstacleVertical(GroundVerticalObstacle6PoolerScript.obstacle6Script.GetPooledObject());
        }

        //26 o 27
        if(rand > 25 && rand < 28)
        {
            //Ostacolo 3 
            SpawnObstacleVertical(GroundVerticalObstacle3PoolerScript.obstacle3Script.GetPooledObject());

            //ostacolo 4
            SpawnObstacleVertical(GroundVerticalObstacle4PoolerScript.obstacle4Script.GetPooledObject());
        }

        //28 o 29
        if(rand > 27 && rand < 30)
        {
            //ostacolo 6
            SpawnObstacleVertical(GroundVerticalObstacle6PoolerScript.obstacle6Script.GetPooledObject());

            //ostacolo 4
            SpawnObstacleVertical(GroundVerticalObstacle4PoolerScript.obstacle4Script.GetPooledObject());
        }
    }


    void SpawnCornersHorizontal()
    {
        int rand = Random.Range(0, 2);          //valori possibili nella creazione random = 0 e 1.

        

        if(rand < 1)
        {
            SpawnCornerLeft();
        }
        else
        {
            SpawnCornerRight();
        }
    }


    void SpawnCornerLeft()
    {
        Vector3 pos = lastPos;

        //pos.x += (sizeCorner / 2) - 0.2f;    //Non Usati  
        //pos.z += (sizeCorner / 2) - 0.2f;    //Non Usati

        lastPos = new Vector3(pos.x + 5.9f, pos.y, pos.z + 1.9f); //DA RIVEDERE PER INCASTRO STACCIONATA OTTIMALE             

        GameObject newObj = Corner2PoolerScript.current2.GetPooledObject();

        if (newObj == null)
        {
            return;
        }

        newObj.transform.position = pos;
        newObj.transform.rotation = Quaternion.Euler(0, 180, 0);
        newObj.SetActive(true);

        if (!gameOver)
        {
            counterHor = 4;
            InvokeRepeating("SpawnHorizontalLeft", 0.1f, timeForCreation);
        }
      
    }


    void SpawnCornerRight()
    {
        Vector3 pos = lastPos;

        pos.x += (sizeCorner / 2) - 0.8f;                   //Aggiustamenti posizioni angoli
        pos.z += (sizeCorner / 2) - 0.5f;

        lastPos = new Vector3(pos.x - 0.2f, pos.y, pos.z);

        GameObject newObj = Corner1PoolerScript.current.GetPooledObject();

        if (newObj == null)
        {
            return;
        }

        newObj.transform.position = pos;
        newObj.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObj.SetActive(true);

        if(!gameOver)
        {
            counterHor = 4;
            InvokeRepeating("SpawnHorizontalRight", 0.1f, timeForCreation);
        }
      
    }


    void SpawnHorizontalLeft()
    {
        direction = 4;      //Sinistra

        Vector3 pos = lastPos;
        pos.x -= size;
        lastPos = new Vector3(pos.x + 0.2f, pos.y, pos.z);

        GameObject newObject = GroundVerticalPoolerScript.poolScript.GetPooledObject();

        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObject.SetActive(true);
        CreateCoins(pos);
        CreatePowerUps(pos);


        if (--counterHor <= 0)
        {
            CancelInvoke("SpawnHorizontalLeft");
           
            if (!gameOver)
            {
                int rand = Random.Range(0, 10);

                

                if (rand > 2)                                                       //DA RIVEDERE PER BUG PIATATFORMA VUOTA SU OBSTACLE 1 DOPO CURVA A SINISTRA
                {
                    SpawnEmptyHorizontalLeft();                                 //Metto una piattaforma vuota tramite una void che poi crea anche altre piattaforme e poi un angolo
                }
                else
                {
                    lastPos = new Vector3(pos.x - 9.5f, pos.y, pos.z + 1.9f);    //Modifico per ottimizzare         //Cambio la lastPos per il Corner perchè non va più bene quello calcolato prima per le piattaforme orizzontali

                    SpawnCornerUp();                                                        //Lancio lo spawn del corner verso l'alto
                }
            }
           
        }
    }


    void SpawnHorizontalRight()
    {
        direction = 2;      //Destra

        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = new Vector3(pos.x - 0.2f, pos.y, pos.z);

        GameObject newObject = GroundVerticalPoolerScript.poolScript.GetPooledObject();

        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObject.SetActive(true);
        CreateCoins(pos);
        CreatePowerUps(pos);


        if (--counterHor <= 0)
        {
            CancelInvoke("SpawnHorizontalRight");

            if (!gameOver)
            {
                int rand = Random.Range(0, 10);

                

                if(rand > 2)
                {
                   SpawnEmptyHorizontalRight();                                 //Metto una piattaforma vuota tramite una void che poi crea anche altre piattaforme e poi un angolo
                }
                else
                {
                    //lastPos = new Vector3(pos.x, pos.y, pos.z);         //Cambio la lastPos per il Corner perchè non va più bene quello calcolato prima per le piattaforme orizzontali

                    SpawnCornerUp();                                                         //Lancio lo spawn del corner verso l'alto
                }
            }
        }
    }











    void SpawnEmptyHorizontalLeft()
    {
        direction = 4;      //Sinistra

        Vector3 pos = lastPos;
        pos.x -= size;
        lastPos = new Vector3(pos.x + 0.2f, pos.y, pos.z);

        GameObject newObject = GroundEmptyVerticalPoolerScript.emptyPoolScript.GetPooledObject();

        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObject.SetActive(true);

        //Subito dopo metto una piattaforma normale altrimenti ci sarebbe subito l'angolo
        pos = lastPos;
        pos.x -= size;
        lastPos = new Vector3(pos.x + 0.2f, pos.y, pos.z);

        newObject = GroundVerticalPoolerScript.poolScript.GetPooledObject();        

        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObject.SetActive(true);
        CreateCoins(pos);
        CreatePowerUps(pos);

        //Metto una piattaforma orizzontale con un ostacolo estraendolo random 

        pos = lastPos;
        pos.x += size;
        lastPos = new Vector3(pos.x - 0.2f, pos.y, pos.z);

        int rand = Random.Range(0, 2);                                      //Agire qui per aggiungere piattaforme

        if (rand < 1)
        {
            newObject = GroundVerticalObstacle1PoolerScript.obstacle1Script.GetPooledObject();
        }
        else
        {
            newObject = GroundVerticalObstacle2PoolerScript.obstacle2Script.GetPooledObject();
        }


        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObject.SetActive(true);
        CreateCoins(pos);
        CreatePowerUps(pos);


        //Metto un'altra piattaforma normale altrimenti anche in questo caso ci sarebbe subito l'angolo

        pos = lastPos;
        pos.x -= size;
        lastPos = new Vector3(pos.x + 0.2f, pos.y, pos.z);

        newObject = GroundVerticalPoolerScript.poolScript.GetPooledObject();

        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObject.SetActive(true);
        CreateCoins(pos);
        CreatePowerUps(pos);

        lastPos = new Vector3(pos.x -9.5f, pos.y, pos.z + 1.9f);    //Modifico per ottimizzare                         //preparazione lastPos per l'angolo

        //metto l'angolo verso l'alto

        SpawnCornerUp();                      
    }



    void SpawnEmptyHorizontalRight()
    {
        direction = 2;      //Destra

        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = new Vector3(pos.x - 0.2f, pos.y, pos.z);

        GameObject newObject = GroundEmptyVerticalPoolerScript.emptyPoolScript.GetPooledObject();

        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObject.SetActive(true);

        //Subito dopo metto una piattaforma normale altrimenti ci sarebbe subito l'angolo

        pos.x += size;
        lastPos = new Vector3(pos.x - 0.2f, pos.y, pos.z);

        newObject = GroundVerticalPoolerScript.poolScript.GetPooledObject();

        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObject.SetActive(true);
        CreateCoins(pos);
        CreatePowerUps(pos);

        //Metto una piattaforma orizzontale con un ostacolo estraendolo random 

        pos.x += size;
        lastPos = new Vector3(pos.x - 0.2f, pos.y, pos.z);

        int rand = Random.Range(0, 2);

        if (rand < 1)
        {
            newObject = GroundVerticalObstacle1PoolerScript.obstacle1Script.GetPooledObject();
        }
        else
        {
            newObject = GroundVerticalObstacle2PoolerScript.obstacle2Script.GetPooledObject();
        }
            

        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObject.SetActive(true);
        CreateCoins(pos);
        CreatePowerUps(pos);

        //Metto un'altra piattaforma normale altrimenti anche in questo caso ci sarebbe subito l'angolo

        pos.x += size;
        lastPos = new Vector3(pos.x - 0.2f, pos.y, pos.z);

        newObject = GroundVerticalPoolerScript.poolScript.GetPooledObject();

        if (newObject == null)
        {
            return;
        }

        newObject.transform.position = pos;
        newObject.transform.rotation = Quaternion.Euler(0, 90, 0);
        newObject.SetActive(true);

        lastPos = new Vector3(pos.x, pos.y, pos.z);                             //preparazione lastPos per l'angolo

        //metto l'angolo verso l'alto

        SpawnCornerUp();                     
    }


    void SpawnCornerUp()
    {
        Vector3 pos = lastPos;

        if(direction == 2)
        {
            lastPos = new Vector3(pos.x + 1.9f, pos.y, pos.z + 1.8f);  //Modifico per ottimizzare

            GameObject newObj = Corner3PoolerScript.current3.GetPooledObject();

            if (newObj == null)
            {
                return;
            }

            newObj.transform.position = pos;
            newObj.transform.rotation = Quaternion.Euler(0, -90, 0);
            newObj.SetActive(true);
        }
        else
        {
            lastPos = new Vector3(pos.x, pos.y, pos.z -0.2f);  

            GameObject newObj = Corner4PoolerScript.current4.GetPooledObject();

            if (newObj == null)
            {
                return;
            }

            newObj.transform.position = pos;
            newObj.transform.rotation = Quaternion.Euler(0, 0, 0);
            newObj.SetActive(true);
        }

        direction = 1;   //Verso l'alto

        if(!gameOver)
        {
            CreateCombinations();

            counterUp = 5;

            InvokeRepeating("SpawnVertical", 0.1f, timeForCreation);
        }
    }
}











       





    