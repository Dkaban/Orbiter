using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
    private List<GameObject> _pooledObjects;
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool;
    
    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        _pooledObjects = new List<GameObject>();
        for (var i = 0; i < amountToPool; i++)
        {
            var temp = Instantiate(objectToPool, transform, true);
            temp.SetActive(false);
            _pooledObjects.Add(temp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (var i = 0; i < amountToPool; i++)
        {
            if (!_pooledObjects[i].activeInHierarchy)
            {
                return _pooledObjects[i];
            }
        }

        return null;
    }
}
