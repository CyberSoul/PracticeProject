﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public delegate void ChangeColorClick();
    public static event ChangeColorClick onChangeColorClick;

    [SerializeField] Player m_player;

    [SerializeField] GameObject m_pausedView;

    [SerializeField] Toggle m_lookAt;
    [SerializeField] Toggle m_slerp;

    // Start is called before the first frame update
    void Start()
    {
        m_slerp.onValueChanged.AddListener((bool On) => 
        {
            m_player.Slerp = On;
            if (On)
                m_lookAt.isOn = false; 
            });
        m_lookAt.onValueChanged.AddListener((bool On) => 
        {
            m_player.LookAt = On;
            if (On)
                m_slerp.isOn = false;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowPauseView(bool a_isEnable)
    {
        m_pausedView.active = a_isEnable;
    }

    public void ChangeColorForCubes()
    {
        if (onChangeColorClick != null)
        {
            onChangeColorClick();
        }
    }
}