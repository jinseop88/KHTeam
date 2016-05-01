using UnityEngine;
using System.Collections;

public class SkillImpactInfo : MonoBehaviour 
{
    /// <summary>
    /// 임펙트가 생성될 위치
    /// </summary>
    public Vector3 m_vImpactPos;

    /// <summary>
    /// 임펙트의 크기
    /// </summary>
    public float m_fRadius;

    /// <summary>
    /// 데미지 판정할 콜리더
    /// </summary>
    private SphereCollider m_Collider;

    public void Initialize()
    {
        //데미지 판정에 사용할 콜리더 받아놓는다
        m_Collider = NGUITools.FindInParents<SphereCollider>(gameObject);

    }

    public void Casting()
    {

    }

    /// <summary>
    /// 구형의 데미지 판정 
    /// </summary>
    bool TestImpactSphere(Vector3 position)
    {
        bool hited = false;

        Collider[] colliders = Physics.OverlapSphere(position, m_radius, m_targetLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            Actor target = colliders[i].GetComponent<Actor>();

            // 같은편은 공격 안함
            if (owner.IsAllied(target))
                continue;

            // 이미 충돌된 객체는 다시 체크 안함
            if (CheckCollided(target.thisObject))
                continue;

            if (onHit != null)
                onHit(target, this);

            hited = true;
        }

        return hited;
    }
}
