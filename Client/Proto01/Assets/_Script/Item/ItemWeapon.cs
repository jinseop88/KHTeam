using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ItemWeapon : ItemBase
{
    void Awake()
    {
        m_eItemType = eItemType.Weapon;
    }

    
}
