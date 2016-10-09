using UnityEngine;
using System.Collections;

public class CharacterTestScene : MonoBehaviour, IGameEventListener
{
    public SpawnPoint m_characerSpawnPoint;
    public SpawnPoint m_monsterSpawnPoint;

    private FollowCamera m_camera;

    private int m_monsterKillCount;
    private int m_dayCount;

    public MapType my;

    private Vector3 m_monsterSpawnDistance = new Vector3(15f, 0f, 0f);

    void Awake()
    {
        GameEventManager.Register(this);

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
    }

    private void CreateMap()
    {
        Debug.Log(my);
        MapManager.Instance.ChangeMap(MapType.Mt_ChunTae1);
    }

    private void CreateMonster()
    {
        IngameManager.Instance.SpawnMonster(MonsterManager.Instance.GetNextMonster(), 1, m_monsterSpawnPoint);
        m_monsterSpawnPoint.transform.Translate(m_monsterSpawnDistance);
    }

    public void OnGameEvent(GameEventType gameEventType, params object[] args)
    {
        switch (gameEventType)
        {
            case GameEventType.MonsterDied:
                m_monsterKillCount = m_monsterKillCount + 2;
                DayIncreasedByKillCount(m_monsterKillCount);

                CreateMonster();
                break;
            default:
                break;
        }
    }

    public void DayIncreasedByKillCount(int mon_killCount)
    {
        Debug.Log(mon_killCount + "마리를 죽였습니다.");
        float day;

        if (mon_killCount != 0)
        {
            day = (float)(mon_killCount / 2);
            MapChangeByDayCount(day);
        }
    }

    public void MapChangeByDayCount(float dayCount)
    {

        Debug.Log(dayCount + "일이 지났습니다.");
        if(dayCount != 0)
        {
            if (1 <= dayCount && dayCount <= 3)
            {
                return;
            }
            if (4 <= dayCount && dayCount <= 6)
            {                
                MapManager.Instance.ChangeMap(++my);
               
            }
        }   

    }

}
