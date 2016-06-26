using UnityEngine;
using System.Collections;

public class SceneGame : SceneBase
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
        //yield return null;
        AsyncOperation cLoadLevelAsync = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Stage1-1");
        yield return cLoadLevelAsync;

        //UIManager.Instance.Initialize();
        //UIManager.Instance.OpenUI(eUIType.Title);

        //UI_Title temp = UIManager.Instance.GetUI<UI_Title>(eUIType.Title);
        //temp.Initialize();
    }

    public override void Exit()
    {
        base.Exit();
        //UIManager.Instance.CloseUI(eUIType.Title);
    }


}
