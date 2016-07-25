﻿using UnityEngine;
using System.Collections;

public class Monster : Actor 
{
    void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();

        onDamage = OnDamage;

        AISystem = thisObject.AddComponent<MonsterAI>();
        ((MonsterAI)AISystem).m_Owner = this;
        ((MonsterAI)AISystem).m_Sight = 5f;
        ((MonsterAI)AISystem).m_LimitDistance = 3f;
        ((MonsterAI)AISystem).m_AtkDelay = 2f;

        AISystem.AIOn();
    }

    private void OnDamage(BaseEntity attacker, SkillImpactInfo skillImpact)
    {
        animation2D.OnDamage();
        currentHP -= 80f;

        if(currentHP <= 0f)
        {
            animation2D.OnDead();
            Invoke("Delete", 0.5f);
        }
    }

    public void Delete()
    {
        Destroy(thisObject);
    }

    void OnEnable()
    {
        IngameManager.Instance.m_monsterList.Add(this);
    }
    void OnDisable()
    {
        IngameManager.Instance.m_monsterList.Remove(this);
    }
}
