using UnityEngine;
using System.Collections;

public class CycleMoveController : MonoBehaviour
{
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

    protected Vector3 m_velocityInput;

    public float movedLength { set; get; }

    public void SetRotation(Quaternion rot)
    {
        Vector3 pathDir = PathDir();
        if (pathDir == Vector3.zero)// 라인밖으로 나갔을때 거리가 0이라 값이 0,0,0이 온다.
            return;
    }

    public void AddTranslate(Vector3 velocity)
    {
        MoveByPath(velocity*5f);
    }

    public Vector3 PathDir()
    {
        return BSpline.Instance.Velocity(movedLength / BSpline.Instance.maxLength,
            (movedLength + 0.1f) / BSpline.Instance.maxLength);
    }

    void MoveByPath(Vector3 velocity)
    {
        // 이동 거리
        Vector3 pathForce = velocity;
        pathForce.y = 0.0f;
        pathForce.z = 1.0f;

        float force = pathForce.magnitude;
        if (Vector3.Dot(PathDir(), pathForce) < 0.0f)
            force *= -1.0f;

        Vector3 pos;
        if (Mathf.Abs(force) > 0.0f)
        {
            pos = BSpline.Instance.Evaluate(movedLength / BSpline.Instance.maxLength);

            pos += PathDir() * force;
            pos.y = thisTransform.position.y;// +velocity.y;
           
            movedLength = BSpline.Instance.FindClosetPosition(pos) * BSpline.Instance.maxLength;
        }
        else
        {
            //이동 거리 보간(0 ~ Path 최대이동거리)
            movedLength = Mathf.Clamp(movedLength + force, 0.0f, BSpline.Instance.maxLength);

            // 이동 거리에 따른 Path상의 위치                                        
            Vector3 dest = BSpline.Instance.Evaluate(movedLength / BSpline.Instance.maxLength);

            // 높이값은 안씀
            dest.y = thisTransform.position.y;

            // 이동
            pos.x = dest.x;
            pos.z = dest.z;
            pos.y = thisTransform.position.y;// +velocity.y;
        }

        thisTransform.position = pos;
    }
}
