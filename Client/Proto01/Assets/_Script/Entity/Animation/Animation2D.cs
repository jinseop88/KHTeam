using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Animation2D : MonoBehaviour
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

    protected Actor m_owner;

    public Animator m_animator;


    public void Initialize()
    {
        m_owner = thisObject.GetComponent<Character>();

    }

    #region 애니메이션 실행함수

    public virtual void OnMove(bool bMove)
    {
        m_animator.SetBool(GameType.AnimationState.Move.ToString(), bMove);
    }
    /// <summary>
    /// 공격
    /// </summary>
    /// <param name="state"></param>
    public virtual void OnAttack()
    {
        m_animator.SetTrigger("Attack");
    }

    /// <summary>
    /// 점프
    /// </summary>
    public virtual void OnJump()
    {
        m_animator.SetTrigger(GameType.AnimationState.Jump.ToString());
    }

    public virtual void OnDamage()
    {
        m_animator.SetTrigger(GameType.AnimationState.Damage.ToString());
    }
    /// <summary>
    /// 죽었을때 
    /// </summary>
    public virtual void OnDead()
    {
        m_animator.SetBool(GameType.AnimationState.Dead.ToString(), true);
    }
    #endregion
    #region 애니메이션 확인함수

    #endregion
}
