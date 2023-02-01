using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public bool isNotGear = true;
    public static CameraScript cameraScript;

    private void Awake()
    {
        if(cameraScript == null)
        {
            cameraScript = this;
        }
    }



    
    public Transform player;

    [SerializeField]
    float maxAngle = 7f;

    private Vector3 offsetPosition;

    // Start is called before the first frame update
    void Start()
    {
        offsetPosition = transform.position;                            //Calcola distanza tra cam e player attraverso la distanza che c'è tra la cam e il punto 0 di x,y,z
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = player.TransformPoint(offsetPosition);     //Reset posizione camera alla stessa posizione che aveva inizialmente rispetto al player


            var targetRotation = Quaternion.LookRotation(player.position - new Vector3(transform.position.x, transform.position.y - 2f, transform.position.z));              //Quaternion per le rotazioni per girare a destra e sinistra con la cam 

            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, maxAngle);
        
    }
}
