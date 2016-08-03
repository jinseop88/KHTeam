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
        Debug.Log(m_lbInputName.text);
        SetActive(false);
    }

    public void ClickCancel()
    {
        SetActive(false);
    }
}
