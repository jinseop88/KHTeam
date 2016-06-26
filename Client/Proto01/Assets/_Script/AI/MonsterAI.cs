using UnityEngine;
using System.Collections;

public class MonsterAI : BaseAI
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
    /// 시야
    /// </summary>
    public float m_Sight;

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
    /// 나지금 공격당했니?
    /// </summary>
    public bool m_bHited;

    /// <summary>
    /// Target을 발견했는가?
    /// </summary>
    public bool m_bIsDetection;

    public override void UpdateAI()
    {
        // 1. 타겟설정(없어졌을경우)
        if (m_Target == null)
        {
            ReTarget();
            return;
        }
        // 2. 거리확인(AI시작)
        if (!m_bIsDetection && GetDistance() < m_Sight)
        {
            m_bIsDetection = true;
            return;
        }

        // 3. 발견했는가?
        if (!m_bIsDetection) return;

        //쳐다본다
        LookAtTarget();

        // 3. 거리확인 (다가가기)
        if(GetDistance() > m_LimitDistance)
            m_Owner.Move();
        else
            m_Owner.MoveStop();

        // 4. 공격가능확인
        if(IsPossibleAttack())
        {
            ProcessAttack();
            return;
        }

        // 5. 맞았으면 분노한다.
        if(m_bHited)
        {
            //분노
        }
    }

    /// <summary>
    /// 둘간거리
    /// </summary>
    /// <returns></returns>
    public float GetDistance()
    {
        return Mathf.Abs(m_Owner.thisTransform.position.x - m_Target.thisTransform.position.x);
    }

    /// <summary>
    /// 타겟이 없어졌으면 다시 차자보쟙
    /// </summary>
    /// <returns></returns>
    public void ReTarget()
    {
        m_Target = GameObject.FindObjectOfType<Character>();
    }

    /// <summary>
    /// 상대 바라보기
    /// </summary>
    public void LookAtTarget()
    {
        eDirection eDir;
        if (m_Owner.thisTransform.position.x - m_Target.thisTransform.position.x > 0)
            eDir = eDirection.Left;
        else
            eDir = eDirection.Right;

        m_Owner.SetDirection(eDir);
    }

    /// <summary>
    /// 공격가능하냐?
    /// </summary>
    public bool IsPossibleAttack()
    {
        return m_LastAtkTime + m_AtkDelay < Time.realtimeSinceStartup;
    }

    /// <summary>
    /// 공격 ㄱ
    /// </summary>
    public void ProcessAttack()
    {
        m_Owner.Attack(GameType.AnimationState.Projectile);
        m_LastAtkTime = Time.realtimeSinceStartup;
    }

}
