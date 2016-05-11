using UnityEngine;
using System.Collections;

public class UI_StageSelector : UIBase
{

    public UIPage_Chapter m_uiChapter;
    public UIPage_Stage m_uiStage;


    public void ClickChapter(GameObject obj)
    {

        switch (obj.name)
        {
            case "Button_Chapter_1":
                Debug.Log("1번눌렸어요");
                break;
            case "Button_Chapter_2":
                Debug.Log("2번눌렸어요");
                break;
            case "Button_Chapter_3":
                Debug.Log("3번눌렸어요");
                break;
            case "Button_Chapter_4":
                Debug.Log("4번눌렸어요");
                break;
        }
    }
}
