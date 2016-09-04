using UnityEngine;
using System.Collections;

public class SceneGame : SceneBase
{
    private SpawnPoint m_characerSpawnPoint;
    private SpawnPoint m_monsterSpawnPoint;

    private MonsterSpawner m_monsterSpawner;

    private FollowCamera m_camera;

    private Vector3 m_monsterSpawnDistance = new Vector3(15f, 0f, 0f);

    public override void Enter()
    {
        StartCourotine(Loading());
    }

    IEnumerator Loading()
    {
        AsyncOperation cLoadLevelAsync = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("1.GameScene");
        yield return cLoadLevelAsync;

        UIManager.Instance.OpenUI<UI_DressRoom>(eUIType.DressRoom);

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
        MapManager.Instance.ChangeMap(MapType.Mt_ChunTae1);
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

                CreateMonster();
                break;
            default:
                break;
        }
    }
}
