using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; //For func and actions.

public delegate void SomeEventHandler(string a_someText);

public class EventsExample : MonoBehaviour
{
    public Action<Vector3> OnMove;

    public Func<int, string> SomeFunc;// delegate string SomeDelegate(int); SomeDelegate someFunc;

    //Another class can subscribe for this event
    public event SomeEventHandler m_event;

    static public event SomeEventHandler m_staticEvent;

    // Start is called before the first frame update
    void Awake()
    {
        m_event += CustomLog; //Can be any other class.
    }

    private void OnDestroy()
    {
        m_event -= CustomLog;//Can be any other class.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            m_event("some text string");
        }
    }

    static public void CustomLog(string a_logText)
    {
        Debug.Log($"Custom log: {a_logText}");
    }
}
