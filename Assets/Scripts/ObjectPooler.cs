
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject[] objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        pooledObjects = new List<GameObject>();
        
        //ensures loop through all objects to pool
        for (int j = 0; j < objectToPool.Length; j++)
        {
            //for each object
            for (int i = 0; i < amountToPool; i++)
            {
            //bullet
            GameObject obj = Instantiate(objectToPool[j]);
            obj.SetActive(false);
            pooledObjects.Add(obj);
            obj.transform.SetParent(this.transform); // set as children of Game Manage
            }
        }
            
    }


    public GameObject GetPooledObject(string tag)
    {
        foreach (GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy && obj.CompareTag(tag))
            {
                return obj;
            }
        }
        return null;
    }


}
