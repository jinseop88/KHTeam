using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
public class ItemSoul : ItemBase
{
    void Awake()
    {
        m_eItemType = eItemType.Soul;
    }    

    /// <summary>
    /// 부딫혔을때
    /// </summary>
    /// <param name="other"></param>
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("character"))              
        {
            GetItem();
        }

    }

    /// <summary>
    /// 먹은후 처리
    /// </summary>
    public void GetItem()
    {
        Destroy(gameObject, 0f);
    }
}
