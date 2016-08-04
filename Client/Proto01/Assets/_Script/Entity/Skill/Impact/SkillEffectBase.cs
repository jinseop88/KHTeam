using UnityEngine;
using System.Collections;

public class SkillEffectBase : MonoBehaviour 
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

    public Actor owner { get; set; }

    /// <summary>
    /// 이펙트가 시작될 시간
    /// </summary>
    public float m_startTime;

    /// <summary>
    /// 이펙트가 지속될 시간
    /// </summary>
    public float m_totalTime;

    /// <summary>
    /// 현재 시작되었나?
    /// </summary>
    protected bool m_bStart;

    public virtual void Initialize() 
    { 

    }
    public virtual void Reset(){}

    protected virtual void StartEffect(){}
    protected virtual void UpdateEffect() { }
    protected virtual void EndEffect(){}
    public void UpdateEffect(float fTime)
    {
        if (fTime < m_startTime)
        {
            //아직 시작 아님
        }
        else if (fTime > m_startTime)
        {
            if (m_bStart)
                UpdateEffect();
            else
            {
                //시작
                m_bStart = true;
                StartEffect();
            }
        }
        else if (fTime > m_startTime + m_totalTime && m_bStart)
        {
            //끝
            EndEffect();
        }
        
    }
}
