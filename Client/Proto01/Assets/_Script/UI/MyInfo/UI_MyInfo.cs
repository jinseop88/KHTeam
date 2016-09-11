using UnityEngine;
using System.Collections;

public class UI_MyInfo : UIBase
{
    public UILabel coinCount;
    public UILabel flowerCount;
    public UISprite insamGauge;
    public int insamMaxCount = 100;

    void OnGUI()
    {
        coinCount.text = MyInfo.instance.coinCount.ToString();
        flowerCount.text = MyInfo.instance.flowerCount.ToString();

        float insamGaugePercent = Mathf.Clamp((float)MyInfo.instance.insamCount / (float)insamMaxCount, 0.0f, 1.0f);

        UISprite uiSprite = insamGauge.GetComponent<UISprite>();
        uiSprite.fillAmount = insamGaugePercent;

        if (insamGaugePercent >= 1.0f)
        {
            GameEventManager.Notify(GameEventType.ReadyMagic);
        }
    }
}