using UnityEngine;
using System.Collections;

public class UIPage_Coin : UIBase
{
    public UILabel m_lbCoinCount;

    private uint m_uiCoinCount;

    public uint coinCount
    {
        set
        {
            m_uiCoinCount = value;
            m_lbCoinCount.text = m_uiCoinCount.ToString();
        }
        get
        {
            return m_uiCoinCount;
        }
    }

    public override void Initialize()
    {
        base.Initialize();

        // Initialaize member variables.
        m_uiCoinCount = 0;
    }
}
