using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonExample : MonoBehaviour
{
    private static SingletonExample m_instance;
    public static SingletonExample Instance
    {
        get
        {
            if (m_instance == null)
            {
                //Debug.LogError("The SingletonExample is NULL");
                //Lazy initiat on first call.
                GameObject obj = new GameObject("SingletonExample");
                obj.AddComponent<SingletonExample>();
                
                //Just my version: can instantiate from template.
            }

            return m_instance;
        }
    }

    private void Awake()
    {
        m_instance = this;
    }

    public void SomeMethod()
    {
        //Do something.
    }

}
