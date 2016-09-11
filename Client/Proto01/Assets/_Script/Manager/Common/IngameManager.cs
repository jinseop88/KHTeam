using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IngameManager : SingleTon<IngameManager>, IGameEventListener
{
    public Character m_myCharacter;
    public List<Monster> m_monsterList = new List<Monster>();

    public IngameManager()
    {
        GameEventManager.Register(this);
    }

    void OnGUI()
    {
        GUI.Box(new Rect(150, 85, 900, 50), GUIContent.none);

        GUI.Label(new Rect(200, 100, 200, 100), "KillCount -> " + MyInfo.instance.monsterKillCount);

        if(GUI.Button(new Rect(0,100,100,100), "PlayerPrefs Clear"))
        {
            PlayerPrefs.DeleteAll();
        }
    }


    public void SpawnMonster(Monster monster, int count, SpawnPoint spawnPoint)
    {
        for (int i = 0; i != count; ++i)
        {
            Instantiate(monster.thisObject, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public void SpawnItem(GameType.ItemType itemType, Vector3 vSpawnPos)
    {
        GameObject ObjItem = Resources.Load("Prefabs/Item/" + itemType.ToString()) as GameObject;

        GameObject clone = GameObject.Instantiate(ObjItem, vSpawnPos, Quaternion.identity) as GameObject;

        clone.GetComponent<ItemBase>().Initialize();
    }

    private void Update()
    {
        ///Check Click Action
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //    GameEventManager.Notify(GameEventType.ClickScreen);
    }

    public void OnGameEvent(GameEventType gameEventType, params object[] args)
    {
        switch(gameEventType)
        {
            case GameEventType.SpawnItem :
                int rndCount = (int)args[0] % 4;
                Vector3 spawnPos = (Vector3)args[1];

                for (int i = 0; i < rndCount; i++ )
                    SpawnItem((GameType.ItemType)(Random.Range(0, 1000) % (int)GameType.ItemType.Max), spawnPos);

                break;
        }
    }
}
