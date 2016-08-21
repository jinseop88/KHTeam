using UnityEngine;
using System.Collections;

public class CharacterTestScene : MonoBehaviour, IGameEventListener
{
    public SpawnPoint m_characerSpawnPoint;
    public SpawnPoint m_monsterSpawnPoint;

    private Character m_myCharacter;
    private MonsterSpawner m_monsterSpawner;

    private FollowCamera m_camera;

    private int m_monsterKillCount;
    private Vector3 m_monsterSpawnDistance = new Vector3(5f, 0f, 0f);

    void Awake()
    {
        GameEventManager.Instance.Register(this);

        m_camera = GameObject.FindObjectOfType<FollowCamera>();

        CreateCharacter();
        CreateGameSystem();
        CreateMap();
        CreateMonster();

        m_camera.m_target = m_myCharacter.thisTransform;
    }

    void Start()
    {
        m_myCharacter.AISystem.AIOn();
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
    }

    private void CreateMap()
    {
        //MapManager.Instance.ChangeMap(MapType.Mt_ChunTae, 3);
    }

    private void CreateMonster()
    {
        m_monsterSpawner.Spawn(MonsterManager.Instance.GetNextMonster(), 1, m_monsterSpawnPoint);
        m_monsterSpawnPoint.transform.Translate(m_monsterSpawnDistance);
    }

    public void OnGameEvent(GameEventType gameEventType)
    {
        switch (gameEventType)
        {
            case GameEventType.MonsterDied:
                ++m_monsterKillCount;
                Debug.Log(m_monsterKillCount);

                CreateMonster();
                break;
            default:
                break;
        }
    }
}
