using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SomeDataClass
{
    public int m_id;
    public string m_name;
    public string m_someData;
}

public class Player : MonoBehaviour
{
    [SerializeField] float m_speed;
    [SerializeField] float m_maxSpeed = 10;
    [SerializeField] float m_rotationSpeed;

    [SerializeField] bool m_isLookAt;
    [SerializeField] bool m_isSlerp;
    [SerializeField] GameObject m_target;

    [SerializeField] SomeDataClass[] m_arrayWithSomeData;

    //[SerializeField] bool m_isSpeedUp;

    // Start is called before the first frame update
    void Start()
    {

    }

    public bool LookAt
    {
        get => m_isLookAt;
        set { m_isLookAt = value; }
    }
    public bool Slerp {
        get => m_isSlerp;
        set { m_isSlerp = value; }
    }
    public bool SpeedUp { get; set; }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();

        if (Input.GetButtonDown("Fire1"))
        {
            TestExplodeAroundMe();
        }

        if (m_isLookAt)
        {
            Vector3 distance = m_target.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(distance);
            Debug.DrawRay(transform.position, distance, Color.green);
        }
        if (m_isSlerp)
        {
            Vector3 distance = m_target.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(distance);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
            Debug.DrawRay(transform.position, distance, Color.blue);
        }
    }
    
    void MovementUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vecrtical = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Rotation");

        transform.Translate(new Vector3(horizontal, 0, vecrtical) * m_speed * Time.deltaTime);
        transform.Rotate(Vector3.up, rotation * m_rotationSpeed * Time.deltaTime);
    }

    void TestExplodeAroundMe()
    {
        var boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var box in boxes)
        {
            var rigidbody = box.GetComponent<Rigidbody>();
            if (rigidbody)
            {
                rigidbody.AddExplosionForce(500, transform.position, 1);
            }
        }
    }

    public void SpeedUpFunction()
    {
        StartCoroutine(speedRoutine());
    }

    public void ResetSpeed( int newSpeed)
    {
        m_speed = newSpeed;
    }

    IEnumerator speedRoutine()
    {
        while (m_speed < m_maxSpeed)
        {
            yield return new WaitForSeconds(1.0f);
            m_speed += 1;
        }
    }
}
