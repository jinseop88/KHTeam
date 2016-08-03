using UnityEngine;
using System.Collections;

public class UIPage_Chapter : UIBase
{
    public void ClickChapter(GameObject obj)
    {
        switch(obj.name)
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

        SceneManager.Instance.ChangeScene(SceneType.Game);
    }

    
}
