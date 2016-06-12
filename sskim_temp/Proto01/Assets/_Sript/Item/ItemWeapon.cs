using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ItemWeapon : ItemBase
{
    void Awake()
    {
        m_eItemType = eItemType.Weapon;
    }

    public override void GetItem()
    {
        base.GetItem();

        Debug.Log("나는 웨폰이에요");
    }
}
