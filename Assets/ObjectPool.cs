using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPool : MonoBehaviour {

    public GameObject prefab;
    public int initialPoolSize = 10;
    private int poolSize;

    private void Start()
    {
        poolSize = initialPoolSize;

        for(int i = 0; i < initialPoolSize; ++i)
        {
            GameObject o = Instantiate(prefab);
            o.SetActive(false);
            o.transform.parent = transform;
        }
    }

    
    public GameObject GetObject()
    {
        foreach(Transform child in transform)
        {
            if(!child.gameObject.activeInHierarchy)
            {
                return child.gameObject;
            }
        }

        for (int i = 0; i < poolSize; ++i)
        {
            GameObject o = Instantiate(prefab);
            o.SetActive(false);
            o.transform.parent = transform;
        }
        poolSize *= 2;

        return transform.GetChild(poolSize / 2).gameObject;
    }

}
