using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonTemplate<T> : MonoBehaviour where T : SingletonTemplate<T>
{
    private static T m_instance;

    public static T Instance
    {
        get
        {
            if (m_instance == null)
            {
                Debug.LogError($"Null instance for singleton of {typeof(T).ToString()}");
                //GameObject obj = new 
            }

            return m_instance;
        }
    }

    private void Awake()
    {
        m_instance = this as T; // (T)this

        Init();
    }

    public void Init()
    {
    }
}
