using UnityEngine;
using System.Collections;

public class UISansam_System : UIBase
{

    public UILabel m_lbSansamCount;
    private int m_uiSansamCount;

    public override void Initialize()
    {
        base.Initialize();

        GameObject.Find("UI_GoodSystem").GetComponent("GoodSystem");
    }

    // Use this for initialization
    void Start () {
        Initialize();

        m_uiSansamCount = GoodSystem.m_SansamCount;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public int SansamCount
    {
        set
        {
            m_uiSansamCount = value;
            m_lbSansamCount.text = (m_uiSansamCount + "뿌리").ToString();
            PlayerPrefs.SetInt("Sansam", m_uiSansamCount);

        }
        get
        {
            return m_uiSansamCount;
        }
    }
}
