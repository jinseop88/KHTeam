using UnityEngine;
using System.Collections;

public class UI_Test : UIBase
{
    public UIPage_Coin m_uiPageCoin;
    public UIPage_Hp m_uiHpCount;

    public override void Initialize()
    {
        base.Initialize();

        m_uiPageCoin.Initialize();
        m_uiHpCount.Initialize();

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

    IEnumerator DamagedHpCount()
    {

        m_uiHpCount.hpCount = m_uiHpCount.hpCount - 10;          //UILabel을 m_uiHpCount로 선언후 HPCount함수에 값을 1더해서 보내준다.

        //yield return new WaitForSeconds(0.5f);
        yield return null;

    }
    void OnGUI()
    {
        if (GUI.Button(new Rect(80, 50, 100, 100), "Button"))
        {
            if (m_uiHpCount.hpCount > 0)
                StartCoroutine(DamagedHpCount());

        }
    }

}

