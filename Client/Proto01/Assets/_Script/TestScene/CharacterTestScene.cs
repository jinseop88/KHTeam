using UnityEngine;
using System.Collections;

public class CharacterTestScene : MonoBehaviour 
{

    private Character m_myCharacter;
    private MonsterSpawner m_spawner;

    public CharacterSpawnPoint m_characerSpawnPoint;
    public CharacterSpawnPoint m_monsterSpawnPoint;

    void Start()
    {
        m_myCharacter = CharacterManager.Instance.CreateCharacter();
        m_myCharacter.Initialize();

        GameObject objSpawner = new GameObject("objSpawner");
        m_spawner = objSpawner.AddComponent<MonsterSpawner>();

        m_myCharacter.AISystem.AIOn();
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(100,100,100,100),"Spawn"))
        {
            MonsterSpawner.Request request = new MonsterSpawner.Request(MonsterManager.Instance.CreateMonster(MonsterType.GoblinFire).thisObject, 1);
            m_spawner.SendRequest(request);
        }
    }

}
