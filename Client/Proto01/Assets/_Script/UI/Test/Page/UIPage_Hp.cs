using UnityEngine;
using System.Collections;

public class UIPage_Hp : UIBase
{
    
    public UILabel m_lbHpCount;      
    private int m_uiHpCount;                

    public int hpCount
    {
        set
        {
            //Initialize()에서 초기값을 매개변수로 받아서 value값으로 저장
            m_uiHpCount = value;                        
            m_lbHpCount.text = m_uiHpCount.ToString();
        }
        get
        {
            return m_uiHpCount;
        }
    }

    public override void Initialize()
    {
        base.Initialize();

        // Initialaize member variables.
        m_uiHpCount = 100;
    }

    

}
