using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqExample : MonoBehaviour
{
    [SerializeField] string[] m_someStringData = { "one", "2", "три", "search", "another data", "and one more"};
    [SerializeField] string m_searchData = "search";
    // Start is called before the first frame update
    void Start()
    {
        bool isContainSearch = m_someStringData.Any(data => data == m_searchData);
        Debug.Log($"Our search result: {isContainSearch}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
