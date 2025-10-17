using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PoolElements
{
    List<GameObject> m_Elements;
    int m_CurrentElementId = 0;

    public void Init(int Count, GameObject PrefabElement)
    {
        m_Elements = new List<GameObject>();
        for (int i = 0; i < Count; i++) 
        {
            GameObject l_GameObject = GameObject.Instantiate(PrefabElement);
            l_GameObject.SetActive(false);
            m_Elements.Add(l_GameObject);
        }
    }
    public GameObject GetNextElement() 
    {
        GameObject l_GameObject = m_Elements[m_CurrentElementId];
        ++m_CurrentElementId;
        if (m_CurrentElementId > m_Elements.Count)
            m_CurrentElementId = 0;
        return l_GameObject;
    }
}
