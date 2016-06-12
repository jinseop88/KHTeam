using UnityEngine;
using System.Collections;

public class UI_Title : UIBase
{
    public GameObject m_objButtonGroup;
    public Page_Create m_pageCreate;

    public override void Initialize()
    {
        base.Initialize();
        m_objButtonGroup.SetActive(true);
        m_pageCreate.SetActive(false);
    }

    public void ClickStartButton()
    {
        startGame();
    }


    // Main Function
    public void startGame()
    {
        Debug.Log(PlayerPrefs.GetString("PlayName") + "who?");
        // Player Not Exist
        if (PlayerPrefs.GetString("PlayName") == null || PlayerPrefs.GetString("PlayName").Equals(""))
        {
            Debug.Log("Player Not Exist");
            m_pageCreate.SetActive(true);
        }
        else
        {
            //Move To GameLobby
            Debug.Log("Game Start!");
            SceneManager.Instance.ChangeScene(SceneType.Lobby);
            //UnityEngine.SceneManagement.SceneManager.LoadScene("2.GameLobby");
        }
    }
}
