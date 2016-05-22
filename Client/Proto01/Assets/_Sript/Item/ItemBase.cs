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

    /// <summary>
    /// 부딫혔을때
    /// </summary>
    /// <param name="other"></param>
    protected void OnTriggerEnter(Collider other)
    {
        GetItem();
    }

    /// <summary>
    /// 먹은후 처리
    /// </summary>
    public virtual void GetItem()
    {
        Debug.Log("아이템을 먹었어요");
    }
}
