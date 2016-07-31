using UnityEngine;
using System.Collections;

public class UIFlower_System : UIBase
{

    public UILabel m_lbFlowerCount;
    private int m_uiFlowerCount;

    public override void Initialize()
    {
        base.Initialize();

        GameObject.Find("UI_GoodSystem").GetComponent("GoodSystem");
    }

    // Use this for initialization
    void Start () {
        Initialize();

        m_uiFlowerCount = GoodSystem.m_FlowerCount;

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int FlowerCount
    {
        set
        {
            m_uiFlowerCount = value;
            m_lbFlowerCount.text = (m_uiFlowerCount + "송이").ToString();            
            PlayerPrefs.SetInt("Flower", m_uiFlowerCount);           

        }
        get
        {
            return m_uiFlowerCount;
        }
    }
}
