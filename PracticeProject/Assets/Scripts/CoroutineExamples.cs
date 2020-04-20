using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExamples : MonoBehaviour
{
    [SerializeField] GameObject[] m_testObjects;
    [SerializeField] float m_timeDelay = 1f;

    Coroutine m_coroutineAll;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.O) )
        {
            m_coroutineAll = StartCoroutine(RecolorCoroutineAll());
            //StartCoroutine("RecolorCoroutineAll"); //Worked.
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            //If coroutine started by string => stop by string
            StopCoroutine(m_coroutineAll);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(RecolorCoroutineOneAfterOne());
        }

    }

    public IEnumerator RecolorCoroutineAll()
    {
        foreach ( var obj in m_testObjects)
        {
            obj.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
            yield return new WaitForSeconds(m_timeDelay);
        }
    }


    public IEnumerator RecolorCoroutineOneAfterOne()
    {
        Debug.Log("Start all recolor");
        foreach (var obj in m_testObjects)
        {
            Debug.Log("Start recolor new item");
            //setup color;
            obj.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
            yield return new WaitForSeconds(m_timeDelay);
            //return to white color and setup next to rand color in same frame
            Debug.Log("Return white color");
            obj.GetComponent<Renderer>().material.color = Color.white;
        }

        Debug.Log("Complete all recolors");
    }
}
