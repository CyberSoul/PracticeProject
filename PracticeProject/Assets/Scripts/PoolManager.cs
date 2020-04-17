using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : SingletonTemplate<PoolManager>
{
    [SerializeField] GameObject m_bulletPrefab;
    [SerializeField] int m_bulletAmount;
    [SerializeField] GameObject m_bulletContainer;

    private List<GameObject> m_bullets = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateBullets(m_bulletAmount);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateBullets( int a_amount)
    {
        for ( int i =0; i< a_amount; ++i)
        {
            GameObject obj = Instantiate(m_bulletPrefab, m_bulletContainer.transform);
            obj.SetActive(false);
            m_bullets.Add(obj);
        }
    }

    public GameObject RequestBullet()
    {
        foreach (var bullet in m_bullets)
        {
            if ( !bullet.activeInHierarchy )
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject newObj = Instantiate(m_bulletPrefab, m_bulletContainer.transform);
        m_bullets.Add(newObj);

        return newObj;
    }
}
