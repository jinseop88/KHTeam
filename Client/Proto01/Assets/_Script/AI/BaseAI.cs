using UnityEngine;
using System.Collections;

public class BaseAI : MonoBehaviour, IAIController
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
    /// AI켜진상태인가?
    /// </summary>
    private bool m_bIngUpdate;

    public void AIOn()
    {
        m_bIngUpdate = true;
    }
    public void AIOff()
    {
        m_bIngUpdate = false;
    }

    private void Update()
    {
        if (m_bIngUpdate)
            UpdateAI();
    }

    protected virtual void UpdateAI()
    {

    }
}
