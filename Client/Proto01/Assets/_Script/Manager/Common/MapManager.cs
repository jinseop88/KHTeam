using UnityEngine;
using System.Collections;


public enum MapType
{
    Mt_ChunTae1,
    Mt_ChunTae2,
    Town_Kiwa,
    Town_RockTower,
    Pound_Moon,
    Cave1_Purple,
    Cave1_Blue,
    Max,
}

public class MapManager : SingleTon<MapManager>
{
    private GameObject m_objPreviousMap;
    private GameObject m_objCurrentMap;

    private MapType m_currentMapType = MapType.Max;

	public void ChangeMap(MapType eNextMapType)
    {
		if (eNextMapType == m_currentMapType)
			return;
		
        m_currentMapType = eNextMapType;

        GameEventManager.Notify(GameEventType.MapChanged, eNextMapType);

		FadeScreen.Instance.StartFadeScreen (0.0f, 1f, 1f, 0, Color.black);

		GameObject objNextMap = InnerLoadMap(eNextMapType, IngameManager.Instance.m_myCharacter.thisTransform.position);
		Destroy (m_objCurrentMap);
		m_objCurrentMap = objNextMap;
		/*
        if (m_objCurrentMap == null)
        {
            m_objCurrentMap = InnerLoadMap(eNextMapType);
            return;
        }
        else
        {
            GameObject objNextMap = InnerLoadMap(eNextMapType);
            GameObject temp = m_objPreviousMap; //삭제 될친구

            m_objPreviousMap = m_objCurrentMap;
            m_objCurrentMap = objNextMap;            
          
            Background[] nextBackGround = m_objCurrentMap.GetComponentsInChildren<Background>(true);
            Background[] backgrounds = m_objPreviousMap.GetComponentsInChildren<Background>(true);

            for (int i = 0; i < nextBackGround.Length; i++)
            {
                for (int j = 0; j < backgrounds.Length; j++)
                {
                    if(nextBackGround[i].distanceType == backgrounds[j].distanceType)
                    {
                        nextBackGround[i].transform.Translate(new Vector3(backgrounds[j].GetEndX(), 0, 0));
                        break;
                    }
                }                
            }

            for (int i = 0; i < backgrounds.Length; i++)
                backgrounds[i].enabled = false;

            if (temp != null)
                Destroy(temp);
        }*/
    }

	private GameObject InnerLoadMap(MapType eNextMapType, Vector3 spawnPos)
    {
        GameObject objMap = Resources.Load("Prefabs/Map/" + eNextMapType.ToString() + "/" + eNextMapType.ToString()) as GameObject;

		GameObject clone = GameObject.Instantiate(objMap, spawnPos, Quaternion.identity) as GameObject;

        return clone;
    }
}
