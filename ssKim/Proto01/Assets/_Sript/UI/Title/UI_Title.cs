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
        Debug.Log("PlayGame!");
		UnityEngine.SceneManagement.SceneManager.LoadScene("10.AnimTestScene");
    }
}
