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

    public virtual void Initialize() { }
    public virtual void Casting(){}
    public virtual void Cancel(){}
    public virtual void Reset(){}
}
