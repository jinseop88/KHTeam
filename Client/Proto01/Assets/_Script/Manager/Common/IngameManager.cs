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

        GUI.Label(new Rect(200, 100, 200, 100), "CoinCount -> " + MyInfo.instance.coinCount);
        GUI.Label(new Rect(400, 100, 200, 100), "FlowerCount -> " + MyInfo.instance.flowerCount);
        GUI.Label(new Rect(600, 100, 200, 100), "InsamCount -> " + MyInfo.instance.insamCount);
        GUI.Label(new Rect(800, 100, 200, 100), "KillCount -> " + MyInfo.instance.monsterKillCount);

        if(GUI.Button(new Rect(0,100,100,100), "Basic"))
        {
            m_myCharacter.ApplySkin(GameType.SkinType.Basic);
        }
        if (GUI.Button(new Rect(0, 200, 100, 100), "GoodDress"))
        {
            m_myCharacter.ApplySkin(GameType.SkinType.GoodDress);
        }
        if (GUI.Button(new Rect(0, 300, 100, 100), "RoseDress"))
        {
            m_myCharacter.ApplySkin(GameType.SkinType.RoseDress);
        }
        if (GUI.Button(new Rect(0, 400, 100, 100), "PinkDress"))
        {
            m_myCharacter.ApplySkin(GameType.SkinType.PinkDress);
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
            GameEventManager.Notify(GameEventType.Click_Screen);
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
