using UnityEngine;
using System.Collections;

public class DelayDestroy : MonoBehaviour 
{
    public float m_fDelay;

    private float m_fRemainTime;

    void Awake()
    {
        m_fRemainTime = m_fDelay;
    }
    void Update()
    {
        if(m_fRemainTime > 0)
        {
            m_fRemainTime -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
