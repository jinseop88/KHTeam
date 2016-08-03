using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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


    [SerializeField]
    protected Animator m_animator;
    protected AnimatorOverrideController m_controller;
    protected Actor m_owner;

    [System.Serializable]
    public class AnimStateInfo
    {
        public GameType.AnimationState state;
        public string name;
        public int nameHash;
        public AnimationClip clip;
    }

    [HideInInspector, SerializeField]
    public List<AnimStateInfo> m_animStateInfo = new List<AnimStateInfo>();

    public Dictionary<GameType.AnimationState, int> m_animHash;

    public void Initialize()
    {
        m_controller = new AnimatorOverrideController();
        m_controller.runtimeAnimatorController = m_animator.runtimeAnimatorController;

        if (m_animStateInfo != null)
        {
            m_animHash = new Dictionary<GameType.AnimationState, int>();

            for (int i = 0; i < m_animStateInfo.Count; i++)
            {
                // mechanim state와 IActorAnimation state 를 매칭할 해시코드 생성
                try
                {
                    m_animHash.Add((GameType.AnimationState)System.Enum.Parse(typeof(GameType.AnimationState), m_animStateInfo[i].name), m_animStateInfo[i].nameHash);
                }
                catch (System.Exception e)
                {
                    Debug.LogError(e.Message);
                }

                m_controller[m_animStateInfo[i].name] = m_animStateInfo[i].clip;
            }
        }

        m_animator.runtimeAnimatorController = m_controller;
    }

    public void SetBool(string param, bool val)
    {
        m_animator.SetBool(param, val);
    }

    public void SetTrigger(string param)
    {
        m_animator.SetTrigger(param);
    }

    public void SetFloat(string param, float val)
    {
        m_animator.SetFloat(param, val);
    }

    public bool GetBool(string param)
    {
        return m_animator.GetBool(param);
    }

    public bool IsPlaying(params GameType.AnimationState[] states)
    {
        for (int i = 0; i < states.Length; i++)
        {
            if (!m_animHash.ContainsKey(states[i]))
                continue;

            for (int j = 0; j < m_animator.layerCount; j++)
            {
                if (m_animator.GetCurrentAnimatorStateInfo(j).shortNameHash == m_animHash[states[i]])
                    return true;
            }
        }

        return false;
    }


    #region 애니메이션 실행함수

    public virtual void OnMove(bool bMove)
    {
    }
    /// <summary>
    /// 공격
    /// </summary>
    /// <param name="state"></param>
    public virtual void OnAttack()
    {
        m_animator.SetTrigger("Attack");
    }

    public virtual void OnDamage()
    {
        
    }

    /// <summary>
    /// 죽었을때 
    /// </summary>
    public virtual void OnDead()
    {
    }
    #endregion

    #region 애니메이션 확인함수

    #endregion

}
