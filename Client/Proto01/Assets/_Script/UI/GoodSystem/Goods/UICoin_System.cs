using UnityEngine;
using System.Collections;

public class UICoin_System : UIBase
{

    public UILabel m_lbCoinCount;
    private int m_uiCoinCount; 
    

    public override void Initialize()
    {
        
        base.Initialize();

        /// <summary>
        /// GameSystem Script참조
        /// </summary>
        GameObject.Find("UI_GoodSystem").GetComponent("GoodSystem");
    }

    // Use this for initialization
    void Start ()
    {
        Initialize();

        /// <summary>
        /// GameSystem Script의 m_CoinCount 가져오기
        /// </summary>
        m_uiCoinCount = GoodSystem.m_CoinCount;
    }	

    public int coinCount
    {
        set
        {
            m_uiCoinCount = value;
            //if (m_uiCoinCount >= 100)
            //{
            //    int coinX = (int)m_uiCoinCount / 100;
            //    int coinY = m_uiCoinCount % 100;
            //    m_lbCoinCount.text = (coinX + "A " + coinY).ToString();

            //}
            //else if (m_uiCoinCount >= 10000)
            //{
            //    int coinX = (int)m_uiCoinCount / 10000;
            //    int coinY = (m_uiCoinCount % 10000) / 10000;
            //    int coinZ = (m_uiCoinCount % 10000) % 10000;
            //    m_lbCoinCount.text = (coinX + "B " + coinY + "A " + coinZ).ToString();
                

            //}
            //else
            //{
            m_lbCoinCount.text = (m_uiCoinCount+"냥").ToString();
            //}
            PlayerPrefs.SetInt("Coin", m_uiCoinCount);
            //PlayerPrefs.SetInt("Coin", 0);

        }
        get
        {
            return m_uiCoinCount;
        }
    }
}
