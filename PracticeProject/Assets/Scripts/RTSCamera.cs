using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    //Applied to perspective camera
    [SerializeField] Camera m_affecetedCamera;
    [SerializeField] float m_zoomOutMin = 1;
    [SerializeField] float m_zoomOutMax = 10;

    [SerializeField] Vector3 m_planePosition = new Vector3();

    Plane m_plane;//Used for calculate world position
    Vector3 m_touchStart;

    // Start is called before the first frame update
    void Start()
    {
        m_plane = new Plane(Vector3.down, m_planePosition); //Maybe move first param into serialize

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_touchStart = GetWorldPositionForRTS();//m_affecetedCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.touchCount == 2)
        {
            Touch touch0 = Input.GetTouch(0);
            Touch touch1 = Input.GetTouch(1);

            Vector2 touchPrevPos0 = touch0.position - touch0.deltaPosition;
            Vector2 touchPrevPos1 = touch1.position - touch1.deltaPosition;

            float prevMagnitude = (touchPrevPos0 - touchPrevPos1).magnitude;
            float currentMagnitude = (touch0.position - touch1.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = m_touchStart - GetWorldPositionForRTS();
            m_affecetedCamera.transform.position += direction;
        }

        Zoom(Input.GetAxis("Mouse ScrollWheel")); //Active when launched on computer in editor or realese.
    }

    void Zoom(float a_increment)
    {
        m_affecetedCamera.fieldOfView = Mathf.Clamp(m_affecetedCamera.fieldOfView - a_increment, m_zoomOutMin, m_zoomOutMax);
    }

    private Vector3 GetWorldPosition()
    {
        //Based on camera`s rotation
        Ray mousePos = m_affecetedCamera.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(m_affecetedCamera.transform.forward, new Vector3(0,0,0));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
    
    private Vector3 GetWorldPositionForRTS()
    {
        Ray mousePos = m_affecetedCamera.ScreenPointToRay(Input.mousePosition);
        float distance;
        m_plane.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }
}
