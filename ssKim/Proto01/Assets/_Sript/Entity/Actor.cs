using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : MonoBehaviour
{
    #region Actor구성
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

    public static List<Actor> m_ActorList = new List<Actor>();

    void Awake()
    {
        if (!m_ActorList.Contains(this))
            m_ActorList.Add(this);
    }
    void OnDestroy()
    {
        m_ActorList.Remove(this);
    }
    #endregion


    public virtual void Initialize()
    {

    }
    
}
