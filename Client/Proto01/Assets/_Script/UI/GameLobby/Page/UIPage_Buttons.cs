using UnityEngine;
using System.Collections;

public class UIPage_Buttons : UIBase
{
    
    public void ClickCharacterButton()
    {
        Debug.Log("캐릭터 버튼눌림");
    }

    public void ClickSettingButton()
    {
        Debug.Log("셋팅 버튼눌림");
    }

    public void ClickStoreButton()
    {
        Debug.Log("상점 버튼눌림");
    }

    public void ClickLoginButton()
    {
        Debug.Log("계정 버튼눌림");
    }
}
