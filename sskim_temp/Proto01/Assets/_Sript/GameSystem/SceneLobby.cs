using UnityEngine;
using System.Collections;

public class SceneLobby : SceneBase
{
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
    }

    IEnumerator Loading()
    {
        AsyncOperation cLoadLevelAsync = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("2.GameLobby");
        yield return cLoadLevelAsync;

        UIManager.Instance.OpenUI(eUIType.GameLobby);
        //UIManager.Instance.OpenUI(eUIType.ChapterSelector);
           
        //UI_Title temp = UIManager.Instance.GetUI<UI_Title>(eUIType.GameLobby);
        //temp.Initialize();
    }

    public override void Exit()
    {
        base.Exit();

        UIManager.Instance.CloseUI(eUIType.GameLobby);
    }


}
