using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ItemHealth : ItemBase
{   
    void Awake()
    {
        m_eItemType = eItemType.Potion;
    }      

}
