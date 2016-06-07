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

    public float currentHP = 200f;

    public float maxHP = 200f;

    /// <summary>
    /// 2D전용 애니메이션
    /// </summary>
    public Animation2D animation2D { get; set; }

    /// <summary>
    /// 2D전용 무브먼트
    /// </summary>
    public Movement2D movement2D { get; set; }

    /// <summary>
    /// 입력을 받는 클래스
    /// </summary>
    public InputBase input { get; set; }

    /// <summary>
    /// 캐릭터 전용 배틀
    /// </summary>
    public CharacterBattle battleMy { get; set; }

    /// <summary>
    /// 맞았을대 오는 클래스
    /// </summary>
    public Battle.DamageCallBack onDamage { get; protected set; }

    public virtual void Initialize()
    {

    }

    
    //protected void Update()
    //{
    //    CheckGround();
    //}
    
}
