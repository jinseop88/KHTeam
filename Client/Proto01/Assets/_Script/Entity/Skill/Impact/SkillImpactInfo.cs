using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 스킬의 타격을 담당한다.
/// </summary>
public class SkillImpactInfo : SkillEffectBase 
{
    /// <summary>
    /// 임펙트가 생성될 위치
    /// </summary>
    //public Vector3 m_vImpactPos;

    /// <summary>
    /// 임펙트의 크기
    /// </summary>
    //public float m_radius;

    /// <summary>
    /// 공격할 레이어
    /// </summary>
    [HideInInspector]
    public int m_targetLayer;

    /// <summary>
    /// 데미지 판정할 콜리더
    /// </summary>
    protected SphereCollider m_Collider;

    /// <summary>
    /// 타격이 되었을때 콜백
    /// </summary>
    public Battle.HitCallBack onHit { get; set; }

    /// <summary>
    /// 충돌한 것들
    /// </summary>
    private List<GameObject> m_collidedList = new List<GameObject>();


    public override void Initialize() 
    {
        m_Collider = thisObject.GetComponent<SphereCollider>();
    }
    public override void Reset() 
    {
        m_bStart = false;
        thisObject.SetActive(false);
    }
    protected override void StartEffect()
    {
        m_collidedList.Clear();
        thisObject.SetActive(true);
    }
    protected override void EndEffect()
    {
        thisObject.SetActive(false);
    }

    protected override void UpdateEffect()
    {
        base.UpdateEffect();

        TestImpactSphere();
    }
    /// <summary>
    /// 구형의 데미지 판정 
    /// </summary>
    public bool TestImpactSphere()
    {
        bool hited = false;

        Collider[] colliders = Physics.OverlapSphere(m_Collider.transform.position + m_Collider.center, m_Collider.radius, m_targetLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            Actor target = colliders[i].GetComponent<Actor>();

            if (target == null) return false;

            // 이미 충돌된 객체는 다시 체크 안함
            if (CheckCollided(target.thisObject))
                continue;

            if (onHit != null)
                onHit(target, this);

            hited = true;
        }

        return hited;
    }
    bool CheckCollided(GameObject target)
    {
        if (m_collidedList.Contains(target))
            return true;

        m_collidedList.Add(target);
        return false;;
    }
}
