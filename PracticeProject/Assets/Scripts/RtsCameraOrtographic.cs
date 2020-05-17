using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RtsCameraOrtographic : MonoBehaviour
{
    //Applied for ortographic cameras
    [SerializeField] Camera m_affecetedCamera;
    [SerializeField] float m_zoomOutMin = 1;
    [SerializeField] float m_zoomOutMax = 10;

    Vector3 m_touchStart;

    // Start is called before the first frame update
    void Start()
    {
        if (m_affecetedCamera)
        {
            m_affecetedCamera = Camera.main;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_touchStart = m_affecetedCamera.ScreenToWorldPoint(Input.mousePosition);
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
            Vector3 direction = m_touchStart - m_affecetedCamera.ScreenToWorldPoint(Input.mousePosition);
            m_affecetedCamera.transform.position += direction;
        }

        Zoom(Input.GetAxis("Mouse ScrollWheel")); //Active when launched on computer in editor or realese.
    }

    /*void UpdateSwipePosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_touchStart = m_affecetedCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = m_touchStart - m_affecetedCamera.ScreenToWorldPoint(Input.mousePosition);
            m_affecetedCamera.transform.position += direction;
        }
    }

    void UpdateZoom()
    {
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
        else
        {
            Zoom(Input.GetAxis("Mouse ScrollWheel"));
        }
    }*/

    void Zoom(float a_increment)
    {
        m_affecetedCamera.orthographicSize = Mathf.Clamp(m_affecetedCamera.orthographicSize-a_increment, m_zoomOutMin, m_zoomOutMax);
    }
}
