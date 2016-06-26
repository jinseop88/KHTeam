using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterBattle : Battle 
{
    public Actor character { get { return (Actor)m_owner; } }


    public override void Initialize()
    {
        base.Initialize();

        m_owner = thisObject.GetComponent<Actor>();

        m_skillList = new List<Skill>(thisObject.GetComponentsInChildren<Skill>(true));

        for (int i = 0; i < m_skillList.Count; i++)
            m_skillList[i].Initialize(OnHit);
    }

    public override void Casting(GameType.AnimationState state)
    {
        //해당 스킬을 찾아서
        Skill target = m_skillList.Find(arg => arg.m_animationState == state);
        
        //원거리
        if (state == GameType.AnimationState.Projectile)
        {
            Projectile temp = target.thisObject.GetComponentInChildren<Projectile>();
            GameObject clone = Instantiate(temp.gameObject) as GameObject;

            clone.GetComponent<Projectile>().Fire(character, 
                character.thisTransform.position + (Vector3.up * 1.2f), 
                character.thisTransform.right * 1.2f, 
                character.thisTransform.rotation, 
                8f, 
                OnHit);
        }
        else
        {
            currentSkill = target;
            target.Catsting();
        }

    }

    /// <summary>
    /// 스킬에서 맞았다고 이벤트가 이리로온다.
    /// </summary>
    /// <param name="target"></param>
    /// <param name="impactInfo"></param>
    public void OnHit(Actor target, SkillImpactInfo impactInfo)
    {
        AttachHitEffect(target.thisTransform.position);

        if (target.onDamage != null)
            target.onDamage(m_owner, impactInfo);
    }

    public void AttachHitEffect(Vector2 vPos)
    {
        GameObject resourceUI = Resources.Load("Prefabs/Common/HitEffect", typeof(GameObject)) as GameObject;
        GameObject effect = GameObject.Instantiate(resourceUI) as GameObject;

        effect.transform.localPosition = vPos + (Vector2)(effect.transform.up * 1.5f);
    }
}
