using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqExample : MonoBehaviour
{
    [SerializeField] string[] m_someStringData = { "one", "2", "три", "2", "search", "another data", "and one more"};
    [SerializeField] string m_searchData = "search";
    // Start is called before the first frame update
    void Start()
    {
        bool isContainSearch = m_someStringData.Any(data => data == m_searchData);
        var search2 = m_someStringData.Contains(m_searchData);
        m_someStringData.Distinct();//Remove all duplicates
        var result3 = m_someStringData.Where(data=> data.Length > m_searchData.Length);
        Debug.Log($"Our search result: {isContainSearch}; result2: {search2}");
        Debug.Log($"Words with more symbols than \"{m_searchData}\"");

        var sortedData = m_someStringData.OrderByDescending(data => data);
        var sortedData2 = m_someStringData.OrderByDescending(data => data).Reverse();
        var sortedData3 = m_someStringData.Where(data => data.Length > m_searchData.Length).OrderByDescending(data => data);
        foreach (var data in result3)
        {
            Debug.Log(data);
        }

        Debug.Log("DataQuery:   ");
        var dataQuery = from data in m_someStringData where data.Length > 3 select data;
        var dataQuery2 = m_someStringData.Where(data => data.Length > 3); //Equal to dataQuery.
        foreach (var data in dataQuery)
        {
            Debug.Log(data);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
