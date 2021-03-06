﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ItemInsam : ItemBase 
{
    /// <summary>
    /// 초기화 함수
    /// </summary>
    public override void Initialize()
    {
        base.Initialize();

        m_itemType = GameType.ItemType.Insam;
    }

    /// <summary>
    /// 아이템을 먹었을때 (아이템을 지워주는코드가 항상 있어야한다)
    /// </summary>
    public override void Get() 
    {
        base.Get();

        MyInfo.instance.AddInsam(value);
        Destroy(thisObject);
    }
}
