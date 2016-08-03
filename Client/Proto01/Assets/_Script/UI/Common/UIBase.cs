using UnityEngine;
using System.Collections;

public class UIBase : MonoBehaviour {
  
    #region Object, TransForm
    public GameObject thisObject
    {
        get
        {
            if (m_cachedObject == null)
                m_cachedObject = gameObject;
            return m_cachedObject;
        }
    }
    protected GameObject m_cachedObject;

    public Transform thisTransform
    {
        get
        {
            if (m_cachedTransform == null)
                m_cachedTransform = transform;
            return m_cachedTransform;
        }
    }
    protected Transform m_cachedTransform;

    #endregion
	public virtual void Initialize()
    {

    }

    public void SetActive(bool bActive)
    {
        thisObject.SetActive(bActive);
    }
}
