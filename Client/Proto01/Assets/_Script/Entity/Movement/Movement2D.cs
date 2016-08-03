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

    /// <summary>
    /// 최고속도
    /// </summary>
    public float m_speed;

    public eDirection m_Dir;

    /// <summary>
    /// 점프력
    /// </summary>
    public float m_jump;

    /// <summary>
    /// 땅에잇나??
    /// </summary>
    [HideInInspector]
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
    }
    
    public void FixedUpdate()
    {
        Calculate();
        Translate();
    }

    /// <summary>
    /// 이동시키는 함수
    /// </summary>
    protected void Translate()
    {
        Vector3 delta = m_velocity * Time.fixedDeltaTime;
        m_velocity -= delta;

        thisTransform.position += delta;

        //순간가속도
        instantAccel = thisTransform.position - m_lastPosition;
        
        CheckGround();
        CheckCollision();

        //전위치 저장
        m_lastPosition = thisTransform.position;
    }

    /// <summary>
    /// 이동시킬값 계산하는 함수
    /// </summary>
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
    
    /// <summary>
    /// 중력 적용
    /// </summary>
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
     
    /// <summary>
    /// 바닥인지?
    /// </summary>
    protected void CheckGround()
    {
        //Vector3 startRay = thisTransform.position;
        //startRay.y += 1f;
        //Ray ray = new Ray(startRay, -thisTransform.up);
        //m_bIsGrounded = Physics.Raycast(ray, 1f, 1 << LayerMask.NameToLayer("Ground"));

        Vector2 startRay = (Vector2)thisTransform.position;
        startRay.y += 0.3f;

        m_bIsGrounded = Physics2D.Raycast(startRay, (Vector2)(-thisTransform.up), 0.1f, 1 << LayerMask.NameToLayer("Ground"));
        ApplyGravity();
    }

    /// <summary>
    /// 앞에 벽인지?
    /// </summary>
    protected void CheckCollision()
    {
        //Vector3 startRay = thisTransform.position;
        //Ray ray = new Ray(startRay, thisTransform.right);
        if (Physics2D.Raycast((Vector2)thisTransform.position, (Vector2)thisTransform.right, 1f, 1 << LayerMask.NameToLayer("Wall")))
            thisTransform.position = m_lastPosition;
    }

    /// <summary>
    /// 이동
    /// </summary>
    /// <param name="vInput"></param>
    public void Move(Vector3 vInput)
    {
        m_veloctyInput = vInput;
    }

    /// <summary>
    /// 방향 턴
    /// </summary>
    /// <param name="dir"></param>
    public void SetRotation(eDirection dir)
    {
        thisTransform.rotation = dir == eDirection.Left ? RotationLeft : RotationRight;
        m_Dir = dir;
    } 


    /// <summary>
    /// 점프
    /// </summary>
    public void OnJump()
    {
        m_veloctyForce = Vector3.up * m_jump;
        m_bIsGrounded = false;
    }
    
    
}
