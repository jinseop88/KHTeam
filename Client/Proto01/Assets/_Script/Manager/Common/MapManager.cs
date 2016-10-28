using UnityEngine;
using System.Collections;


public enum MapType
{
    Mt_ChunTae1,
    Mt_ChunTae2,
    Town_Kiwa,
    Town_RockTower,
    Pound_Moon,
	Cave1_Blue,
    Cave2_Purple,
	Cave3_Green,
	Forest1_Green,
	Forest2_Blue,
	Forest3_Purple,
	Sea_Moon1,
	Sea_Moon2,
	Sea_Moon3,
    Max,
}

public class MapManager : SingleTon<MapManager>
{
    private GameObject m_objPreviousMap;
    private GameObject m_objCurrentMap;

    private MapType m_currentMapType = MapType.Max;

	public void ChangeMap(MapType eNextMapType)
    {
		eNextMapType = (MapType)((int)eNextMapType % (int)MapType.Max);
		if (eNextMapType == m_currentMapType)
			return;
		
        m_currentMapType = eNextMapType;

        GameEventManager.Notify(GameEventType.MapChanged, eNextMapType);

		FadeScreen.Instance.StartFadeScreen (0.0f, 1f, 1f, 0.001f, Color.black);

		Vector3 spawnPos = new Vector3 (IngameManager.Instance.m_myCharacter.thisTransform.position.x, 0, 0);
		GameObject objNextMap = InnerLoadMap(eNextMapType, spawnPos);
		Destroy (m_objCurrentMap);
		m_objCurrentMap = objNextMap;
    }

	private GameObject InnerLoadMap(MapType eNextMapType, Vector3 spawnPos)
    {
        GameObject objMap = Resources.Load("Prefabs/Map/" + eNextMapType.ToString() + "/" + eNextMapType.ToString()) as GameObject;

		GameObject clone = GameObject.Instantiate(objMap, spawnPos, Quaternion.identity) as GameObject;

        return clone;
    }

	public void AllLoadMap()
	{
		for (MapType temp = MapType.Mt_ChunTae1; temp < MapType.Max; temp++)
			Resources.Load ("Prefabs/Map/" + temp.ToString () + "/" + temp.ToString ());
	}
}
