using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ItemSoul : ItemBase
{
    void Awake()
    {
        m_eItemType = eItemType.Soul;
    }

    public override void GetItem()
    {
        base.GetItem();

        Debug.Log("나는 영혼이에요");
    }
}
