using UnityEngine;
using System.Collections;

public class CharacterTestScene : MonoBehaviour, IGameEventListener
{
    public CharacterSpawnPoint m_characerSpawnPoint;
    public CharacterSpawnPoint m_monsterSpawnPoint;

    private Character m_myCharacter;
    private MonsterSpawner m_monsterSpawner;

    private int m_monsterKillCount;   

    void Awake()
    {
        GameEventManager.Instance.Register(this);

        CreateCharacter();
        CreateGameSystem();
        CreateMap();
    }

    void Start()
    {
        m_myCharacter.AISystem.AIOn();

        m_monsterSpawner.Spawn(MonsterManager.Instance.GetNextMonster(), 1);
    }

    void CreateCharacter()
    {
        m_myCharacter = CharacterManager.Instance.CreateCharacter();
        m_myCharacter.Initialize();
        m_myCharacter.thisTransform.position = m_characerSpawnPoint.transform.position;
    }

    void CreateGameSystem()
    {
        GameObject gameSystem = new GameObject("GameSystem");

        GameObject monsterSpawner = new GameObject("MonsterSpawner");
        monsterSpawner.transform.parent = gameSystem.transform;
        m_monsterSpawner = monsterSpawner.AddComponent<MonsterSpawner>();
        m_monsterSpawner.transform.position = m_monsterSpawnPoint.transform.position;
    }

    private void CreateMap()
    {
        //MapManager.Instance.ChangeMap(MapType.Mt_ChunTae, 3);
    }

    public void OnGameEvent(GameEventType gameEventType)
    {
        switch (gameEventType)
        {
            case GameEventType.MonsterDied:
                ++m_monsterKillCount;
                Debug.Log(m_monsterKillCount);

                m_monsterSpawner.Spawn(MonsterManager.Instance.GetNextMonster(), 1);
                break;
            default:
                break;
        }
    }
}
