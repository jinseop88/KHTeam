using UnityEngine;
using System.Collections;

public class SceneTitle : SceneBase
{
    public override void Update()
    { 
    }

    public override void Restart()
    {
    }

    public override void Terminate()
    {
        UIManager.Instance.CloseUI(eUIType.Title);
    }

    public override void Enter()
    {
        StartCourotine(Loading());
    }

    IEnumerator Loading()
    {
        AsyncOperation cLoadLevelAsync = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("1.Title");
        yield return cLoadLevelAsync;

        UIManager.Instance.Initialize();
        UIManager.Instance.OpenUI(eUIType.Title);

        UI_Title temp = UIManager.Instance.GetUI<UI_Title>(eUIType.Title);
        temp.Initialize();
    }



}
