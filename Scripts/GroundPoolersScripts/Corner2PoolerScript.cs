using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corner2PoolerScript : MonoBehaviour
{
    public GameObject pooledObject;                                     //Oggetto singolare
    public static Corner2PoolerScript current2;
    public int pooledAmount = 5;
    public bool willGrow = true;                                        //Il numero crescer??

    List<GameObject> pooledObjects;                                    //Lista contenente vari oggetti, plurale


    private void Awake()
    {
        if (current2 == null)
        {
            current2 = this;
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
