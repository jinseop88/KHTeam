using UnityEngine;
using System.Collections;

public class SceneGame : SceneBase
{
    private int MonSterKillCount;
    public int i = 1;

    public override void Update()
    { 
    }

    public override void Restart()
    {
    }

    public override void Terminate()
    {
    }

    public override void Enter()
    {
        StartCourotine(Loading());

        MonSterKillCount = PlayerPrefs.GetInt("MonsterKillCount");
    }
    public override void Exit()
    {
        base.Exit();
        //UIManager.Instance.CloseUI(eUIType.Title);
    }
    IEnumerator Loading()
    {
        //yield return null;
        AsyncOperation cLoadLevelAsync = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("1.GameScene");
        yield return cLoadLevelAsync;

        /// 캐릭터 생성
        CreateCharacter();

        ///몬스터 스폰시스템 생성
        CreateMonsterSpawnSystem();

        ///맵 생성
        CreateMap();
    }

    private void CreateCharacter()
    {
        Character character = CharacterManager.Instance.CreateCharacter();

        character.thisTransform.localPosition = Vector3.zero;
    }

    private void CreateMonsterSpawnSystem()
    {
    }
 
    private void CreateMap()
    {       

        if (MonSterKillCount % 200 == 0)
        {
            //i++;      
            MapManager.Instance.ChangeMap(MapType.Mt_ChunTae1);
            //MonSterKillCount -= 200;
        }
        
        MapManager.Instance.ChangeMap(MapType.Mt_ChunTae1);

       
}

}
