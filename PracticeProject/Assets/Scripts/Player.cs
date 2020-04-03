using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField] float m_speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vecrtical = Input.GetAxis("Vertical");

        transform.Translate( new Vector3(horizontal, 0, vecrtical) * m_speed * Time.deltaTime);
    }
}
