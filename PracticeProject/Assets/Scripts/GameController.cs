using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject m_player;
    [SerializeField] UIController m_uiController;

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
        m_uiController.ShowPauseView(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = m_lastTimeScale;
        m_uiController.ShowPauseView(false);
    }

    public void LookAt(GameObject a_target)
    {
        GameObject a_watcher = m_player;
        Vector3 distance = a_target.transform.position - a_watcher.transform.position;
        a_watcher.transform.rotation = Quaternion.LookRotation(distance);
    }
    public void Slerp(GameObject a_target)
    {
        GameObject a_watcher = m_player;
        Vector3 distance = a_target.transform.position - a_watcher.transform.position;
        //a_watcher.transform.rotation = Quaternion.Sler(distance);
    }


}
