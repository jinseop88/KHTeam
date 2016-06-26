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
        SceneManager.Instance.ChangeScene(SceneType.Lobby);
    }
}
