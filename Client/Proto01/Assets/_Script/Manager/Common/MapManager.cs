﻿using UnityEngine;
using System.Collections;


public enum MapType
{
    Mt_ChunTae1 = 0,
    Mt_ChunTae2 = 1,
    Town_Kiwa = 2,
    Town_RockTower = 3
}

public class MapManager : SingleTon<MapManager>
{
    public GameObject m_currnetMap;    

    public void ChangeMap(MapType eNextMapType)
    {
        if (m_currnetMap == null)
        {
            m_currnetMap = InnerLoadMap(eNextMapType);
            return;
        }

        GameObject objNextMap = InnerLoadMap(eNextMapType);
       
        Destroy(m_currnetMap);
        m_currnetMap = objNextMap;

    }

    private GameObject InnerLoadMap(MapType eNextMapType)
    {
        GameObject objMap = Resources.Load("Prefabs/Map/" + eNextMapType.ToString() + "/" + eNextMapType.ToString()) as GameObject;

        GameObject clone = GameObject.Instantiate(objMap) as GameObject;
        return clone;
    }
}
