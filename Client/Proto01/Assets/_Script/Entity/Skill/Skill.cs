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

    public GameType.AnimationState m_animationState;
    /// <summary>
    /// 스킬의 시간
    /// </summary>
    public float m_fTotalTime;

    /// <summary>
    /// 스킬의 시작시간
    /// </summary>
    protected float m_fStartTime;

    /// <summary>
    /// 스킬종료시간
    /// </summary>
    protected float m_fEndTime;

    /// <summary>
    /// 스킬 타격 이펙트들
    /// </summary>
    protected SkillEffectBase[] m_impactInfos;

    /// <summary>
    /// 지금 실행중인가?
    /// </summary>
    protected bool m_bCasting;

    public void Initialize(Battle.HitCallBack hitCallBack)
    {
        ///SKill 오브젝트 아래있는 임펙트들을 가져온다.
        m_impactInfos = transform.GetComponentsInChildren<SkillEffectBase>(false);
       
        //모든 임펙트들 초기화
        for(int i = 0 ; i < m_impactInfos.Length ; i++)
        {
            m_impactInfos[i].Initialize();
            if(m_impactInfos[i] is SkillImpactInfo)
                ((SkillImpactInfo)m_impactInfos[i]).onHit = hitCallBack;
        }

        ///초기화하고 일단 꺼준다
        thisObject.SetActive(false);
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
            //모든 임펙트들 끔
            for (int i = 0; i < m_impactInfos.Length; i++)
            {
                m_impactInfos[i].Reset();
            }

            m_bCasting = false;
            thisObject.SetActive(false);
        }
    }
    public void EndSkill()
    {
        //모든 임펙트들 초기화
        for (int i = 0; i < m_impactInfos.Length; i++)
        {
            m_impactInfos[i].Reset();
        }
    }
    public void Catsting()
    {
        //케스팅아닐때 시작
        if(!m_bCasting)
        {
            thisObject.SetActive(true);
            m_bCasting = true;
            
            //시작시간과 끝시간을 계산해놓는다
            m_fStartTime = Time.time;
            m_fEndTime = m_fStartTime + m_fTotalTime;

            // 모든 임펙트들 캐스팅
            //for (int i = 0; i < m_impactInfos.Length; i++)
            //    m_impactInfos[i].Reset();
        }
    }

    void Update()
    {
        if(m_bCasting)
        {
            //계산해놓은 끝시간이 지났다면 스킬종료
            if (m_fEndTime < Time.time)
            {
                EndSkill();
                m_bCasting = false;
                thisObject.SetActive(false);
                return;
            }

            for (int i = 0; i < m_impactInfos.Length; i++)
                m_impactInfos[i].UpdateEffect(Time.time - m_fStartTime);
        }
    }
}
