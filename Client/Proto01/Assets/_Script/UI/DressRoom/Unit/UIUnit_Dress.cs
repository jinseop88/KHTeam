using UnityEngine;
using System.Collections;

public class UIUnit_Dress : UIBase
{
    public UISprite m_spDressThumb;

    public UILabel m_lbDressName;
    public UILabel m_lbFlowerPrice;
    public UILabel m_lbDressPrice;


    public override void Initialize()
    {
        base.Initialize();
    }

    public void ClickBuy()
    {
        Debug.Log("구매버튼이 눌림");
    }

    public void SetData(Data.Dress dressData)
    {
        m_lbDressName.text = dressData.name;
        m_lbDressPrice.text = string.Format("{0} 원", dressData.coinPrice);
        m_lbFlowerPrice.text = string.Format("{0} 개", dressData.flowerPrice);

        m_spDressThumb.spriteName = ((GameType.SkinType)dressData.index).ToString();
    }
}
