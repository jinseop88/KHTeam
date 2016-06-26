using UnityEngine;
using System.Collections;

public enum eItemType
{
    None,
    Potion,
    Weapon,
    Soul,
    Max,
}

[RequireComponent(typeof(BoxCollider))]
public class ItemBase : MonoBehaviour 
{
    /// <summary>
    /// 아이템의 타입값.
    /// </summary>
    protected eItemType m_eItemType;

    

   

    
}
