using UnityEngine;
using System.Collections;

public class Page_Create : UIBase 
{
    public UILabel m_lbInputName;

    public override void Initialize()
    {
        base.Initialize();
    }

    public void Check()
    {

    }
    public void ClickCreate()
    {
        //Debug.Log(m_lbInputName.text);
        createPlayer(m_lbInputName.text);
        SetActive(false);
    }

    public void ClickCancel()
    {
        SetActive(false);
    }

    public void createPlayer(string _playName)
    {
        if (_playName.Equals("") || _playName == null)
        {
            Debug.Log("Create Player Fail!");
        }
        else
        {
            PlayerPrefs.SetString("PlayName", _playName);
            PlayerPrefs.SetInt("HP", 100);
            PlayerPrefs.SetInt("WeponLevel", 1);
            PlayerPrefs.SetInt("ClearStage", 1);
            Debug.Log("Create Player Success!");
        }
    }
}
