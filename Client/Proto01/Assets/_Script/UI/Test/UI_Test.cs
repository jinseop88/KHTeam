using UnityEngine;
using System.Collections;

public class UI_Test : UIBase
{
    public UIPage_Coin m_uiPageCoin;

    public override void Initialize()
    {
        base.Initialize();

        m_uiPageCoin.Initialize();

        StartCoroutine(IncreaseCoinCount());
        StartCoroutine(ResetCoinCount());
    }

    void Start()
    {
        Initialize();
    }

    IEnumerator IncreaseCoinCount()
    {
        while (true)
        {
            m_uiPageCoin.coinCount = m_uiPageCoin.coinCount + 1;

            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator ResetCoinCount()
    {
        while (true)
        {
            yield return new WaitForSeconds(10.0f);

            m_uiPageCoin.coinCount = 0;
        }
    }
}

