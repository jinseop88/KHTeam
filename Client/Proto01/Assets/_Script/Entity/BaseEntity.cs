using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseEntity : MonoBehaviour
{

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

    public static List<BaseEntity> m_ActorList = new List<BaseEntity>();

    void Awake()
    {
        if (!m_ActorList.Contains(this))
            m_ActorList.Add(this);
    }
    void OnDestroy()
    {
        m_ActorList.Remove(this);
    }
    public virtual void Initialize()
    {
    }
}
