using UnityEngine;
using System.Collections;

public class SceneGame : SceneBase
{
    private SpawnPoint m_characerSpawnPoint;
    private SpawnPoint m_monsterSpawnPoint;

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

		MapManager.Instance.AllLoadMap();
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

        AudioManager.Instance.PlayAudioClip(AudioClipType.BACKGROUND);
    }

    private void CreateCharacter()
    {
        IngameManager.Instance.m_myCharacter = CharacterManager.Instance.CreateCharacter();
        IngameManager.Instance.m_myCharacter.Initialize();
        IngameManager.Instance.m_myCharacter.thisTransform.position = m_characerSpawnPoint.transform.position;
    }

 
    private void CreateMap()
    {
        //100마리 기준 맵을 소환
        MapManager.Instance.ChangeMap((MapType) (MyInfo.instance.monsterKillCount / 100));
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
                DayIncreasedByKillCount(MyInfo.instance.monsterKillCount);
                CreateMonster();
                break;

            case GameEventType.ChangeSkin:
                GameType.SkinType newSkin = (GameType.SkinType)args[0];

                IngameManager.Instance.m_myCharacter.ApplySkin(newSkin, true);
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
            m_day = (int)(mon_killCount * 0.2f);            
            MapChangeByDayCount(m_day);
        }
    }

    public void MapChangeByDayCount(int dayCount)
    {
        //5일에 한번씩 맵이 바뀐다
        MapManager.Instance.ChangeMap((MapType)(dayCount));
    }    
}
