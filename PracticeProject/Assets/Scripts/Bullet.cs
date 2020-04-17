using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float m_speed = 3;
    [SerializeField] float m_lifeTime = 2;

    private void OnEnable()
    {
        Invoke("Hide", m_lifeTime);//Call method Hide after 1 second.
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            transform.Translate(new Vector3(0, 0, m_speed) * Time.deltaTime);
        }
    }
}
