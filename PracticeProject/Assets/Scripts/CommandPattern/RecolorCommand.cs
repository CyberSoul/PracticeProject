using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolorCommand : ICommand
{
    GameObject m_target;
    Color m_newColor;
    Color m_prevColor;

    public RecolorCommand(GameObject a_obj, Color a_newColor)
    {
        m_target = a_obj;
        m_newColor = a_newColor;
    }

    public void Execute()
    {
        m_prevColor = m_target.GetComponent<MeshRenderer>().material.color;
        m_target.GetComponent<MeshRenderer>().material.color = m_newColor;
    }

    public void Undue()
    {
        m_target.GetComponent<MeshRenderer>().material.color = m_prevColor;
    }
}
