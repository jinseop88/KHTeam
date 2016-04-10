using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CycleMoveController))]
public class CycleBase : MonoBehaviour
{
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

    /// <summary>
    /// 자전거를 구성하는 파츠들
    /// </summary>
    protected PartsBase[] m_cParts = new PartsBase[(int)ePartsType.Max];

    /// <summary>
    /// 속도값 
    /// </summary>
    protected float m_fVelocity = 5f;

    /// <summary>
    /// 가속도값
    /// </summary>
    protected float m_fAccel = 0f;

    /// <summary>
    /// 방향값
    /// </summary>
    protected Vector3 m_vDir;





    CycleMoveController moveController;




    /// <summary>
    /// 파츠가져오는 함수
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="eType"></param>
    /// <returns></returns>
    public T GetPart<T>(ePartsType eType) where T : PartsBase
    {
        return (T)m_cParts[(int)eType];
    }

    public void SetMoveController()
    {
        moveController = thisObject.GetComponent<CycleMoveController>();
        if (moveController == null)
            moveController = thisObject.AddComponent<CycleMoveController>();
    }

    void Start()
    {
        m_cParts[(int)ePartsType.Gear] = new Gear();
        m_cParts[(int)ePartsType.Wheel] = new Wheel();

        SetMoveController();
    }

    void Update()
    {
        //MoveForard(m_fVelocity);
        moveController.AddTranslate(Vector3.one);

        //Debug.Log(CalculateSpeed() + "m/h");
    }

    
    float CalculateVelocity()
    {
        float fValue = 0f;


        return fValue;
    }

    /// <summary>
    /// 단위는 m/h
    /// </summary>
    /// <returns></returns>
    float CalculateSpeed()
    {
        int pedalCount = (int)(CycleMath.secToHour / GetPart<Gear>(ePartsType.Gear).pedalTime);
        int runCount = pedalCount * GetPart<Gear>(ePartsType.Gear).runCountPerPedal;

        float fValue = runCount * GetPart<Wheel>(ePartsType.Wheel).circleMeter;
        return fValue;
    }

    //public void MoveForard(float velocity)
    //{
    //    m_fAccel += velocity;

    //    m_fVelocity += m_fAccel;

    //    transform.Translate(m_vDir * Time.deltaTime * m_fVelocity);

    //}

}
