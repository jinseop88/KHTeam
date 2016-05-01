using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour 
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

    public float m_fTotalTime;

    protected float m_fStartTime;
    protected float m_fNomalizedTime;
    protected float m_fTimeInvert;

    public float normalizedTime { get { return m_fNomalizedTime; } }

    protected SkillImpactInfo[] m_impactInfos;

    protected bool m_bCasting;

    public void Initialize()
    {
        ///SKill 오브젝트 아래있는 임펙트들을 가져온다.
        m_impactInfos = thisObject.GetComponentsInChildren<SkillImpactInfo>();
       
        //모든 임펙트들 초기화
        for(int i = 0 ; i < m_impactInfos.Length ; i++)
        {
            m_impactInfos[i].Initialize();
        }
    }
    public void Reset()
    {
        //케스팅중일때 취소
        if(m_bCasting)
        {
            CancelSkill();
        }
    }
    public void CancelSkill()
    {
        //케스팅중일때 취소
        if (m_bCasting)
        {
            m_bCasting = false;
        }
    }
    public void Catsting()
    {
        //케스팅아닐때 시작
        if(!m_bCasting)
        {
            m_bCasting = true;
            //// 모든 임펙트들 캐스팅
            //for (int i = 0; i < m_impactInfos.Length; i++)
            //    m_impactInfos[i].Casting();
        }
    }

    void Update()
    {
        if(m_bCasting)
        {
            //임펙트가 실행되어야되는 시간이면 켜주는...

        }
    }



    
}
