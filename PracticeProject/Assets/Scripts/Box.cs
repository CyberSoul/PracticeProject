using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIController.onChangeColorClick += ApplyRandColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyRandColor()
    {
        GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    }
}
