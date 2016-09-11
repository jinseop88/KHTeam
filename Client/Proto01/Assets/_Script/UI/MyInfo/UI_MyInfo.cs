using UnityEngine;
using System.Collections;

public class UI_MyInfo : UIBase, IGameEventListener
{
    public UILabel coinCount;
    public UILabel flowerCount;
    public UISprite insamGauge;
    public int insamMaxCount = 100;
    public GameObject magicNotice;

    // Use this for initialization
    void Start ()
    {
        Initialize();

        GameEventManager.Register(this);
    }

    void OnGUI()
    {
        coinCount.text = MyInfo.instance.coinCount.ToString();
        flowerCount.text = MyInfo.instance.flowerCount.ToString();

        float insamGaugePercent = Mathf.Clamp((float)MyInfo.instance.insamCount / (float)insamMaxCount, 0.0f, 1.0f);

        UISprite uiSprite = insamGauge.GetComponent<UISprite>();
        uiSprite.fillAmount = insamGaugePercent;

        if (insamGaugePercent == 1.0f)
        {
            magicNotice.SetActive(true);
        }
    }

    public void OnGameEvent(GameEventType gameEventType, params object[] args)
    {
        switch (gameEventType)
        {
            case GameEventType.ClickScreen:
                if (magicNotice.activeSelf)
                {
                    magicNotice.SetActive(false);
                    MyInfo.instance.insamCount = 0;
                    GameEventManager.Notify(GameEventType.CastMagic);
                }
                break;
        }
    }
}
