using UnityEngine;
using System.Collections;


public enum eDirection
{
    None = -1,
    Left,
    Right,
}
public class Movement2D : MonoBehaviour 
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

    public static Quaternion RotationLeft = Quaternion.Euler(new Vector3(0f, 180f, 0f));
    public static Quaternion RotationRight = Quaternion.identity;

    protected Actor m_owner;

    /// <summary>
    /// 최고속도
    /// </summary>
    public float m_speed;

    /// <summary>
    /// 땅에잇나??
    /// </summary>
    public bool m_bIsGrounded;

    /// <summary>
    /// 전위치
    /// </summary>
    protected Vector3 m_lastPosition;

    /// <summary>
    /// 현재가속도
    /// </summary>
    protected Vector3 m_acceleration;

    /// <summary>
    /// 순간 가속도
    /// </summary>
    protected Vector3 instantAccel;

    /// <summary>
    /// 현재 속도
    /// </summary>
    protected Vector3 m_velocity;

    /// <summary>
    /// 입력 < >
    /// </summary>
    protected Vector3 m_veloctyInput;

    /// <summary>
    /// 힘으로 이동 (점프?)
    /// </summary>
    protected Vector3 m_veloctyForce;


    public void Initialize()
    {
        m_owner = thisObject.GetComponent<Character>();
    }
    protected void SetRotation(eDirection dir)
    {
        thisTransform.rotation = dir == eDirection.Left ? RotationLeft : RotationRight;
    }
    public void FixedUpdate()
    {
        Calculate();
        Translate();
    }
    protected void Translate()
    {
        Vector3 delta = m_velocity * Time.fixedDeltaTime;
        m_velocity -= delta;

        thisTransform.position += delta;

        //순간가속도
        instantAccel = thisTransform.position - m_lastPosition;
        
        ApplyGravity();

        //전위치 저장
        m_lastPosition = thisTransform.position;
    }
    protected void Calculate()
    {
        //여기에 이동연산이 들어가면 좋겠는데..
        // 로컬기준으로 이동시키고 필요한가속도만 더해준다.. 최고속도는 넘지 않는다
        Vector3 inputWorld = thisTransform.TransformVector(m_veloctyInput);
        m_acceleration = (inputWorld * m_speed) - m_velocity;
        m_acceleration.x = Mathf.Clamp(m_acceleration.x, - m_speed, m_speed);

        //x축으로만 움직인다.
        m_acceleration.y = 0;
        m_acceleration.z = 0;

        //받은 힘도 적용(한번만)
        if (m_veloctyForce.sqrMagnitude > 0f)
        {
            m_acceleration += m_veloctyForce;
            m_veloctyForce = Vector3.zero;
        }

        if (m_acceleration.sqrMagnitude > 0f)
            m_velocity += m_acceleration;
    }
    
    protected void ApplyGravity()
    {
        if(m_bIsGrounded)
        {
            // 더이상 아래로 떨어지지 않게 한다
            if (m_velocity.y < 0.0f)
                m_velocity.y = 0.0f;
        }
        else
        {
            m_velocity += (Vector3.up * GameMath.gravity * Time.fixedDeltaTime);
        }
    }
    
    void OnGUI()
    {
        if (GUI.Button(new Rect(100, 150, 100, 100), "Left"))
        {
            SetRotation(eDirection.Left);
        }
        if (GUI.Button(new Rect(200, 150, 100, 100), "Right"))
        {
            SetRotation(eDirection.Right);
        }
        if (GUI.Button(new Rect(100, 250, 100, 100), "Move"))
        {
            m_veloctyInput = Vector3.one;
        }
        if (GUI.Button(new Rect(200, 250, 100, 100), "Stop"))
        {
            m_veloctyInput = Vector3.zero;
        }
        if (GUI.Button(new Rect(300, 250, 100, 100), "Jump"))
        {
            m_veloctyForce = Vector3.up * 7f;
            m_bIsGrounded = false;
        }
        if (GUI.Button(new Rect(100, 350, 100, 100), "Ground True"))
        {
            m_bIsGrounded = true;
        }
        if (GUI.Button(new Rect(200, 350, 100, 100), "Ground flase"))
        {
            m_bIsGrounded = false;
        }
    }
    
}
