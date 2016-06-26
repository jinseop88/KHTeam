using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Battle : MonoBehaviour 
{
    #region transform objcect
    protected GameObject m_cachedObject;
    public GameObject thisObject
    {
        get
        {
            if (m_cachedObject == null)
                m_cachedObject = gameObject;
            return m_cachedObject;
        }
    }

    protected Transform m_cachedTransform;
    public Transform thisTransform
    {
        get
        {
            if (m_cachedTransform == null)
                m_cachedTransform = transform;
            return m_cachedTransform;
        }
    }
    #endregion

    /// <summary>
    /// 콜백들
    /// </summary>
    public delegate void DamageCallBack(BaseEntity attacker, SkillImpactInfo skillImpact);
    public DamageCallBack onDamage;
    public delegate void HitCallBack(Actor target, SkillImpactInfo skillImpact);
    /// <summary>
    /// 사용자 
    /// </summary>
    protected Actor m_owner;

    /// <summary>
    /// 가지고 있는 스킬리스트
    /// </summary>
    protected List<Skill> m_skillList = new List<Skill>();

    /// <summary>
    /// 현재 사용하고 있는 스킬
    /// </summary>
    public Skill currentSkill { get; set; }

    /// <summary>
    /// 초기화
    /// </summary>
    public virtual void Initialize() { }

    /// <summary>
    /// 스킬의 사용
    /// </summary>
    /// <param name="state"></param>
    public virtual void Casting(GameType.AnimationState state) { }

}
