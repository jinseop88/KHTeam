using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ItemHealth : ItemBase
{
    void Awake()
    {
        m_eItemType = eItemType.Potion;
    }

    public override void GetItem()
    {
        base.GetItem();

        Debug.Log("나는 포션이에요");
    }
}
