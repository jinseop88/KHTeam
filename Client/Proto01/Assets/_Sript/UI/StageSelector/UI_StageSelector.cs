using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI_StageSelector : UIBase
{

    public UIPage_Chapter m_uiChapter;
    public UIPage_Stage m_uiStage;


    public void ClickStage(GameObject obj)
    {

        switch (obj.name)
        {
            case "Button_Stage_1":
                //Debug.Log("1번눌렸어요");
                Application.LoadLevel("5.ChapterSelect");
                break;
            case "Button_Stage_2":                
                break;
            case "Button_Stage_3":                
                break;
            case "Button_Stage_4":                
                break;
            

        }
    }

   
}
