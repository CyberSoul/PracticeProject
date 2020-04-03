using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject m_pausedView;

    float m_lastTimeScale;


    // Start is called before the first frame update
    void Start()//Called after OnApplicationPause
    {
        Debug.Log("Start");
        //m_lastTimeScale = Time.timeScale;
    }

    private void Awake() //Called before OnApplicationPause
    {
        Debug.Log("Awake");
        m_lastTimeScale = Time.timeScale;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseAction();
        }
    }

    private void OnApplicationPause(bool pause)
    {
        Debug.Log(pause?"Paused":"Unpaused");
        if (pause)
        {
            PauseGame();
        }
        else
        {
            UnpauseGame();
        }
    }

    public void PauseAction()
    {
        if (Time.timeScale == 0)
        {
            UnpauseGame();
        }
        else
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        m_lastTimeScale = Time.timeScale;
        Time.timeScale = 0;
        m_pausedView.active = true;
    }

    public void UnpauseGame()
    {
        Time.timeScale = m_lastTimeScale;
        m_pausedView.active = false;
    }
}
