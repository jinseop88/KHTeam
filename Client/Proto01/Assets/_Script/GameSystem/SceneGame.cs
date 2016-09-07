using UnityEngine;
using System.Collections;

public class SceneGame : SceneBase
{
    private SpawnPoint m_characerSpawnPoint;
    private SpawnPoint m_monsterSpawnPoint;

    private MonsterSpawner m_monsterSpawner;

    private FollowCamera m_camera;

    private int m_monsterKillCount;

    private int m_dayCount;

    private int m_day;

    public MapType m_map;

    private Vector3 m_monsterSpawnDistance = new Vector3(15f, 0f, 0f);

    public override void Enter()
    {
        StartCourotine(Loading());
    }

    IEnumerator Loading()
    {
        AsyncOperation cLoadLevelAsync = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("1.GameScene");
        yield return cLoadLevelAsync;

        UIManager.Instance.CloseUI(eUIType.Title);
        UIManager.Instance.OpenUI<UI_DressRoom>(eUIType.DressRoom);
        UIManager.Instance.OpenUI<UI_MyInfo>(eUIType.MyInfo);

        ///게임시스템 생성
        CreateGameSystem();
        
        /// 캐릭터 생성
        CreateCharacter();

        ///맵 생성
        CreateMap();

        ///몬스터 생성
        CreateMonster();

        m_camera = GameObject.FindObjectOfType<FollowCamera>();
        m_camera.m_target = IngameManager.Instance.m_myCharacter.thisTransform;

        IngameManager.Instance.m_myCharacter.AISystem.AIOn();
    }

    private void CreateGameSystem()
    {
        SpawnPoint[] spawnPoints = GameObject.FindObjectsOfType<SpawnPoint>();
        for(int i = 0 ; i < spawnPoints.Length ; i++)
        {
            if (spawnPoints[i].m_bIsMonsterSpawnPoint)
                m_monsterSpawnPoint = spawnPoints[i];
            else
                m_characerSpawnPoint = spawnPoints[i];
        }

        GameObject monsterSpawner = new GameObject("MonsterSpawner");
        //monsterSpawner.transform.parent = gameSystem.transform;
        m_monsterSpawner = monsterSpawner.AddComponent<MonsterSpawner>();
    }

    private void CreateCharacter()
    {
        IngameManager.Instance.m_myCharacter = CharacterManager.Instance.CreateCharacter();
        IngameManager.Instance.m_myCharacter.Initialize();
        IngameManager.Instance.m_myCharacter.thisTransform.position = m_characerSpawnPoint.transform.position;
    }

 
    private void CreateMap()
    {
        m_monsterKillCount = MyInfo.instance.monsterKillCount;
        if (m_monsterKillCount <= 100) MapManager.Instance.ChangeMap(m_map);
        if (m_monsterKillCount > 100 && m_monsterKillCount <= 101) MapManager.Instance.ChangeMap(m_map + 1);
        if (m_monsterKillCount > 101 && m_monsterKillCount <= 102) MapManager.Instance.ChangeMap(m_map + 2);
        if (m_monsterKillCount > 140 && m_monsterKillCount <= 200) MapManager.Instance.ChangeMap(m_map + 3);
    }

    private void CreateMonster()
    {
        IngameManager.Instance.SpawnMonster(MonsterManager.Instance.GetNextMonster(), 1, m_monsterSpawnPoint);
        m_monsterSpawnPoint.transform.Translate(m_monsterSpawnDistance);
    }

    public override void HandleEvent(GameEventType gameEventType, params object[] args)
    {
        switch (gameEventType)
        {
            case GameEventType.MonsterDied:
                MyInfo.instance.AddMonsterKill(1);
                Debug.Log(MyInfo.instance.monsterKillCount);
                DayIncreasedByKillCount(MyInfo.instance.monsterKillCount);
                CreateMonster();
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 날짜 계산
    /// 죽인몬스터 20마리당 1일 증가
    /// </summary>
    /// <param name="mon_killCount"></param>
    public void DayIncreasedByKillCount(int mon_killCount)
    {        
             
        if (mon_killCount != 0)
        {
            m_day = mon_killCount / 2;            
            MapChangeByDayCount(m_day);
        }
    }

    public void MapChangeByDayCount(int dayCount)
    {
        Debug.Log(dayCount + "일이 지났습니다.");        

        switch (dayCount)
        {
            case 1: break;                                                        //ChunTae1
            case 11: MapManager.Instance.ChangeMap(m_map); break; //ChunTae1
            case 61: MapManager.Instance.ChangeMap(m_map + 1); break; //ChunTae2
            case 69: MapManager.Instance.ChangeMap(m_map + 2); break; //Town_Kiwa
            case 70: MapManager.Instance.ChangeMap(m_map + 3); break; //Town_RockTower
        }
    }    
}
