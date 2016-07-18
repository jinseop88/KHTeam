using UnityEngine;
using System.Collections;

public class CharacterAI : BaseAI
{
    /// <summary>
    /// AI 돌고 있는 나
    /// </summary>
    public Actor m_Owner;

    /// <summary>
    /// 내가 정한 타겟
    /// </summary>
    public Actor m_Target;

    /// <summary>
    /// Target과의 제한거리
    /// </summary>
    public float m_LimitDistance;

    /// <summary>
    /// 공격 딜레이
    /// </summary>
    public float m_AtkDelay;

    /// <summary>
    /// 마지막 공격시간
    /// </summary>
    public float m_LastAtkTime;

    /// <summary>
    /// 터치 됬나?
    /// </summary>
    public bool m_IsTouched;


    private bool isEnableRange { get { return Vector3.Distance(m_Owner.thisTransform.position, m_Target.thisTransform.position) > m_LimitDistance; } }
    private bool isEnableAttack { get { return m_LastAtkTime + m_AtkDelay < Time.realtimeSinceStartup; } }

    protected override void UpdateAI()
    {
        // 1. 타겟 설정( 못찾으면 리턴)
        if (!UpdateTarget())
            return;

        // 2. 타겟에게 다가가기( 다가가는 중이면 리턴)
        if (ApporachTarget())
            return;

        // 3. 타겟에게 공격(스킬버튼이 눌렸다면 스킬씀)
        ProcessAttack();           
    }

    private bool UpdateTarget()
    {
        return m_Target != null;
    }
    
    private bool ApporachTarget()
    {
        // 다가가기
        if (isEnableRange)
        {            
            m_Owner.Move();
            return true;
        }

        // 다가가기 끝
        return false;
    }

    private void ProcessAttack()
    {
        //터치되었으면 공격
        if (m_IsTouched)
        {
            m_Owner.Attack(GameType.AnimationState.Projectile);
            m_IsTouched = false;
        }

        if(isEnableAttack)
        {
            m_Owner.Attack(GameType.AnimationState.Projectile);
            m_LastAtkTime = Time.realtimeSinceStartup;
        }
    }
}