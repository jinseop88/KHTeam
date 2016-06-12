using UnityEngine;
using System.Collections;

public class UI_GameLobby : UIBase
{
    public UIPage_Chapter m_uiChapter;
    public UIPage_Buttons m_uiButtons;

    public override void Initialize()
    {
        base.Initialize();
    }


    public void stageSet(int _mainStageNumber) {
        for (int i = 0; i < _mainStageNumber; i++)
        {
        }
    }

    public void ClickChapter(GameObject obj)
    {
        switch (obj.name)
        {
            case "Button_Chapter_1":
                break;
            case "Button_Chapter_2":
                break;
            case "Button_Chapter_3":
                break;
            case "Button_Chapter_4":
                break;
        }
    }
}