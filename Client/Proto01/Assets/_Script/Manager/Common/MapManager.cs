using UnityEngine;
using System.Collections;

/// <summary>
/// Map 종류
/// 천태산(Mt_ChunTae)
/// 천태산1~10 : Mt_ChunTae1
/// 천태산11~20 : Mt_ChunTae2
/// 천태산21~30 : Mt_ChunTae3 
/// </summary>
public enum MapType
{
    //천태산 맵 3종류 (Mt_ChunTae1, Mt_ChunTae2, Mt_ChunTae3)
    Mt_ChunTae
}

public class MapManager : SingleTon<MapManager>
{
    public GameObject m_currnetMap;

    public void ChangeMap(MapType eNextMapType, int Mapsequence)
    {
        if (m_currnetMap == null)
        {
            m_currnetMap = InnerLoadMap(eNextMapType, Mapsequence);            
            return;
        }

        GameObject objNextMap = InnerLoadMap(eNextMapType, Mapsequence); 
        //Map 이동
        //objNextMap.AddComponent<MapMove>();

        Destroy(m_currnetMap);
        m_currnetMap = objNextMap;
        
    }

    private GameObject InnerLoadMap(MapType eNextMapType, int Mapsequence)
    {
        GameObject objMap = Resources.Load("Prefabs/Map/" + eNextMapType.ToString() + "/" + eNextMapType.ToString() + Mapsequence) as GameObject;

        GameObject clone = GameObject.Instantiate(objMap) as GameObject;
        return clone;
    }
}

