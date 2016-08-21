using UnityEngine;
using System.Collections;

public class CharacterTestScene : MonoBehaviour, IGameEventListener
{
    public SpawnPoint m_characerSpawnPoint;
    public SpawnPoint m_monsterSpawnPoint;

    private MonsterSpawner m_monsterSpawner;

    private FollowCamera m_camera;

    private int m_monsterKillCount;
    private int m_dayCount;

    private Vector3 m_monsterSpawnDistance = new Vector3(15f, 0f, 0f);

    void Awake()
    {
        GameEventManager.Instance.Register(this);

        m_camera = GameObject.FindObjectOfType<FollowCamera>();

        CreateCharacter();
        CreateGameSystem();
        CreateMap();
        CreateMonster();

        m_camera.m_target = IngameManager.Instance.m_myCharacter.thisTransform;
    }

    void Start()
    {
        IngameManager.Instance.m_myCharacter.AISystem.AIOn();
    }

    void CreateCharacter()
    {
        IngameManager.Instance.m_myCharacter = CharacterManager.Instance.CreateCharacter();
        IngameManager.Instance.m_myCharacter.Initialize();
        IngameManager.Instance.m_myCharacter.thisTransform.position = m_characerSpawnPoint.transform.position;
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
        MapManager.Instance.ChangeMap(MapType.Mt_ChunTae1);
    }

    private void CreateMonster()
    {
        m_monsterSpawner.Spawn(MonsterManager.Instance.GetNextMonster(), 1, m_monsterSpawnPoint);
        m_monsterSpawnPoint.transform.Translate(m_monsterSpawnDistance);
    }

    public void OnGameEvent(GameEventType gameEventType, params Object[] args)
    {
        switch (gameEventType)
        {
            case GameEventType.MonsterDied:                
                ++m_monsterKillCount;
                DayIncreasedByKillCount(m_monsterKillCount); 

                CreateMonster();
                break;
            default:
                break;
        }
    }

    public void DayIncreasedByKillCount(int mon_killCount)
    {
        Debug.Log(mon_killCount+ "마리를 죽였습니다.");
        if(mon_killCount != 0 && mon_killCount % 2 == 0)
        {
            m_dayCount++;
            
            
            MapChangeByDayCount(m_dayCount);
        }
    }

    public void MapChangeByDayCount(int dayCount)
    {
        Debug.Log(dayCount + "일이 지났습니다.");
        if (dayCount != 0 && dayCount % 2 == 0)
        {
            
            Debug.Log("여기서 맵이 바뀌어야함.");

            //맵이 생성되어있다면 맵을 destroy해주고 맵을 바꿔줘야함.
            MapManager.Instance.ChangeMap(MapType.Mt_ChunTae2);
        }
    }
}
