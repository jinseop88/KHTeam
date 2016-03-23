using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour 
{
    Transform m_Transform;
    GameObject m_Object;

    /// <summary>
    /// 질량
    /// </summary>
    private float mass = 1000f;

    /// <summary>
    /// 반지름
    /// </summary>
    private float radius = 100f;

    /// <summary>
    /// 자전축
    /// </summary>
    private Vector3 rotationAxis;

    /// <summary>
    /// 자전속도
    /// </summary>
    private float rotatingVelocity = 1f;

    /// <summary>
    /// 자전방향
    /// </summary>
    private Vector3 rotatingDirection = new Vector3(-1f, 0f, 0f);
	
    void Start () 
    {
        m_Object = gameObject;
        m_Transform = transform;

        rotationAxis = m_Transform.localEulerAngles.normalized;
	}
#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(transform.position, target.position);
    }
#endif


	void Update () 
    {
        RotatingSelf();
	}

    /// <summary>
    /// 자전
    /// </summary>
    void RotatingSelf()
    {
        m_Transform.Rotate((rotatingVelocity * rotatingDirection));
    }
}
