using UnityEngine;
using System.Collections;

/// <summary>
/// 게임상에 존재하면서 발로 차이면 날라가고 화면에서 나갈경우 지워진다.
/// </summary>
public class Skull : BaseEntity 
{
    private GameObject m_thisObject;
    private Transform m_thisTansform;

    public GameObject thisObject { get { return m_thisObject; } }
    public Transform thisTransform { get { return m_thisTansform; } }

    /// <summary>
    /// 뱅글 돌 녀석
    /// </summary>
    public Transform m_trTurnTarget;

    /// <summary>
    /// 굴러가는힘
    /// </summary>
    private Vector3 m_vForce;

    /// <summary>
    /// 전위치저장
    /// </summary>
    private Vector3 m_lastPosition;

    /// <summary>
    /// 액티브된놈인가?
    /// </summary>
    private bool m_bIsActive;

    /// <summary>
    /// 땅에 붙어있는가
    /// </summary>
    private bool m_bIsGrounded;

    void Awake()
    {
        m_thisObject = gameObject;
        m_thisTansform = transform;
        m_bIsActive = false;
    }
    void Update()
    {
        //카메라 시야 밖으로 나가면 삭제
        if (!CheckInCamera())
        {
            Destroy(thisObject);
            return;
        }

        Translate();
    }

    void Translate()
    {
        Vector3 delta = m_vForce * Time.fixedDeltaTime;
        m_vForce -= delta;

        m_thisTansform.position += delta;
        m_trTurnTarget.Rotate(new Vector3(0f, 0f, -delta.x * 90f));

        CheckGround();
        CheckCollision();

        //전위치 저장
        m_lastPosition = thisTransform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            m_bIsActive = true;

            m_vForce = (thisTransform.position - other.transform.position).normalized * 10f;
        }
    }

    protected void CheckGround()
    {
        Vector2 startRay = (Vector2)thisTransform.position;
        //startRay.y += 0.3f;

        m_bIsGrounded = Physics2D.Raycast(startRay, (Vector2)(-thisTransform.up), 0.1f, 1 << LayerMask.NameToLayer("Ground"));

        if (m_bIsGrounded)
        {
            // 더이상 아래로 떨어지지 않게 한다
            if (m_vForce.y < 0.0f)
                m_vForce.y = 0.0f;
        }
        else
        {
            m_vForce += (Vector3.up * GameMath.gravity * Time.fixedDeltaTime);
        }
    }

    protected void CheckCollision()
    {
        if (Physics2D.Raycast((Vector2)thisTransform.position, (Vector2)thisTransform.right, 0.5f, 1 << LayerMask.NameToLayer("Wall")))
            thisTransform.position = m_lastPosition;
    }

    /// <summary>
    /// 화면어디 있는지 확인
    /// </summary>
    bool CheckInCamera()
    {
        Vector3 vScreenPos = Camera.main.WorldToScreenPoint(m_thisTansform.position);

        //왼쪽으로 넘어가거나 오른쪽으로 넘어가면 카메라 밖에 있다는거
        return !m_bIsActive || (vScreenPos.x > 0 && vScreenPos.x < Camera.main.pixelWidth);
    }
}
