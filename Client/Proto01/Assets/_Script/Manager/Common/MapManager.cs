using UnityEngine;
using System.Collections;


public enum MapType
{
    Mt_ChunTae1,
    Mt_ChunTae2,
    Town_Kiwa,
    Town_RockTower,
    Max,
}

public class MapManager : SingleTon<MapManager>
{
    private GameObject m_objPreviousMap;
    private GameObject m_objCurrentMap;

    private MapType m_currentMapType = MapType.Max;

    public void ChangeMap(MapType eNextMapType)
    {
        if (m_currentMapType == eNextMapType) return;
        
        m_currentMapType = eNextMapType;

        //Circle..
        eNextMapType = (MapType)((int)eNextMapType % (int)MapType.Max);

        GameEventManager.Notify(GameEventType.MapChanged, eNextMapType);

        if (m_objCurrentMap == null)
        {
            m_objCurrentMap = InnerLoadMap(eNextMapType);
            return;
        }
        else
        {
            GameObject objNextMap = InnerLoadMap(eNextMapType);

            if (m_objPreviousMap != null)
                Destroy(m_objPreviousMap);

            m_objPreviousMap = m_objCurrentMap;
            m_objCurrentMap = objNextMap;

            Background[] backgrounds = m_objPreviousMap.GetComponentsInChildren<Background>(true);
            for (int i = 0; i < backgrounds.Length; i++)
                backgrounds[i].enabled = false;
            
        }
    }

    private GameObject InnerLoadMap(MapType eNextMapType)
    {
        GameObject objMap = Resources.Load("Prefabs/Map/" + eNextMapType.ToString() + "/" + eNextMapType.ToString()) as GameObject;

        GameObject clone = GameObject.Instantiate(objMap) as GameObject;

        return clone;
    }
}
