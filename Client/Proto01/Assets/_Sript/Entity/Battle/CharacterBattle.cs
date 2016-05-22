using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterBattle : Battle 
{
    public Character character { get { return (Character)m_owner; } }


    public override void Initialize()
    {
        base.Initialize();

        m_owner = thisObject.GetComponent<Character>();

        m_skillList = new List<Skill>(thisObject.GetComponentsInChildren<Skill>(true));

        for (int i = 0; i < m_skillList.Count; i++)
            m_skillList[i].Initialize(OnHit);
    }


    public override void Casting(GameType.AnimationState state)
    {
        //해당 스킬을 찾아서
        Skill target = m_skillList.Find(arg => arg.m_animationState == state);

        //실행 시킴
        //if (currentSkill ==  null)
        //{
            currentSkill = target;
            target.Catsting();
        //}
    }

    /// <summary>
    /// 스킬에서 맞았다고 이벤트가 이리로온다.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="impactInfo"></param>
    public void OnHit(Actor target, SkillImpactInfo impactInfo)
    {
        if (target.onDamage != null)
            target.onDamage(m_owner, impactInfo);
    }
}
