using UnityEngine;
using System.Collections;

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
    public void PlayAnimation(GameType.AnimationState state)
    {
        if (state == GameType.AnimationState.Skill1)
            m_animator.SetTrigger("Skill01");
    }
}
