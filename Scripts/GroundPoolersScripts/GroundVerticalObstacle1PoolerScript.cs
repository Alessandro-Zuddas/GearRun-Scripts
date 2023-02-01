using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundVerticalObstacle1PoolerScript : MonoBehaviour
{
    public GameObject pooledObject;                                     //Oggetto singolare
    public static GroundVerticalObstacle1PoolerScript obstacle1Script;
    public int pooledAmount = 1;
    public bool willGrow = true;                                        //Il numero crescer�?

    List<GameObject> pooledObjects;                                    //Lista contenente vari oggetti, plurale


    private void Awake()
    {
        if (obstacle1Script == null)
        {
            obstacle1Script = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject newObject = (GameObject)Instantiate(pooledObject);
            newObject.SetActive(false);
            pooledObjects.Add(newObject);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }

        }
        if (willGrow)
        {
            GameObject newObject = (GameObject)Instantiate(pooledObject);
            pooledObjects.Add(newObject);
            return (newObject);
        }
        return null;
    }
}
