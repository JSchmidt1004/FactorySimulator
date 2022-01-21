using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonComponent<T> : MonoBehaviour where T : Component
{
    protected static T instance;
    public static T Instance
    {
        get
        {
            //Check if there isn't a currently existing object
            if (instance == null)
            {
                //See if it exists in the hierarchy
                instance = FindObjectOfType<T>();
            }

            //return instance
            return instance;
        }
    }

    protected void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = GetComponent<T>();
            DontDestroyOnLoad(gameObject);
        }
    }

    public void DestroyInstance(bool objectDestroy = true)
    {
        instance = null;
        if (objectDestroy) Destroy(gameObject);
    }


}
