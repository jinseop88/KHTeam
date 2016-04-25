using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UI_Title : UIBase
{
    public override void Initialize()
    {
        base.Initialize();
    }

    public void ClickTitle()
    {
        Debug.Log("눌렸습니다~~");
        UnityEngine.SceneManagement.SceneManager.LoadScene("2.GameLobby");
    }
}
