//using UnityEngine;
//using System.Collections;

//public class PathMoveController : CharacterMoveController
//{
//    /// <summary>
//    /// 벽을 통과할지 여부
//    /// </summary>
//    public bool m_throughCollider = false;

//    private float m_lastMovedLength;

//    public Vector3 offsetLocal { set; get; }

//    /// <summary>
//    /// 기준 벡터 (오른쪽)
//    /// </summary>
//    public override Vector3 right { get { return PathDir(); } }

//    /// <summary>
//    /// 기준 벡터 (왼쪽)
//    /// </summary>
//    public override Vector3 left { get { return -PathDir(); } }

//    /// <summary>
//    /// Path 상에서의 움직인 거리
//    /// </summary>
//    public float movedLength { set; get; }

//    public float appointPostion { set; get; }

//    public override void SetRotation(Quaternion rot)
//    {
//        Vector3 pathDir = PathDir();
//        if (pathDir == Vector3.zero)// 라인밖으로 나갔을때 거리가 0이라 값이 0,0,0이 온다.
//            return;

//        if (rot == RotationRight)
//            m_transform.rotation = Quaternion.LookRotation(pathDir);
//        else
//            m_transform.rotation = Quaternion.LookRotation(-pathDir);
//    }

//    public override void AddTranslate(Vector3 velocity)
//    {
//        MoveByPath(velocity);
//    }

//    public override void SetPosition(Vector3 pos)
//    {
//        float t = BSpline.Instance.FindClosetPosition(pos);
//        movedLength = t * BSpline.Instance.maxLength;

//        Vector3 path = BSpline.Instance.Evaluate(t);
//        path.y = pos.y;

//        m_transform.position = path;
//    }
    
//    public override void Initialize()
//    {
//        base.Initialize();

//        m_velocityTweak = new Vector3(1.0f, 0.0f, 1.0f);
//    }

//    protected override void Translate()
//    {
//        // 프레임당 이동 벡터
//        Vector3 velocity = TakeVelocityAtFixedTime(ref m_velocityInput);
//        velocity += TakeVelocityAtFixedTime(ref m_velocityForce);

//        MoveByPath(velocity);

//        // 순간 가속도
//        // 로직 처리시에 필요할때가 있어서 미리 구해 놓는다
//        instantAccel = m_transform.position - m_lastPosition;

//        CheckGround();

//        if (!m_throughCollider)
//        {
//            if (CheckCollision())
//                movedLength = m_lastMovedLength;
//        }

//        m_lastPosition = m_transform.position;
//        m_lastMovedLength = movedLength;
//    }

//    public Vector3 PathDir()
//    {
//        return BSpline.Instance.Velocity(movedLength / BSpline.Instance.maxLength,
//            (movedLength + 0.1f) / BSpline.Instance.maxLength);
//    }

//    void MoveByPath(Vector3 velocity)
//    {
//        // 이동 거리
//        Vector3 pathForce = velocity;
//        pathForce.y = 0.0f;

//        float force = pathForce.magnitude;
//        if (Vector3.Dot(PathDir(), pathForce) < 0.0f)
//            force *= -1.0f;

//        // 2015-12-29 banghojun 
//        // OLD -> 이동한 만큼 패스상에서의 거리를 가져오면 공식에 의한 근사치를 가져 오기 때문에 포인트 갯수에 따라서
//        // 속도가 달라지는 문제가 있었다
//        // 
//        // NEW -> 패스에서는 방향값만 가져오고 캐릭터의 속도로 이동시켰다.
//        // 정확한 방향값을 가져오기 위해 movedLength값을 갱신해줘야 하는데 이는 FindClosetPosition을 통해 계산했다.
//        // Galaxy S2 기준으로 매프레임 0.0002~0.0003 sec 정도의 시간이 걸림
//        // 만약 좀더 최적화를 하고 싶다면 FindClosetPosition의 오차 허용 범위값을 늘려주면 된다(현재 0.0001f)

//        ////////////////////////////////////////////////////////////////////////////////////
//        // old
//        ////////////////////////////////////////////////////////////////////////////////////
//// 
////         // 이동 거리 보간(0 ~ Path 최대이동거리)
////         movedLength = Mathf.Clamp(movedLength + force, 0.0f, BSpline.Instance.maxLength);
//// 
////         // 이동 거리에 따른 Path상의 위치                                        
////         Vector3 dest = BSpline.Instance.Evaluate(movedLength / BSpline.Instance.maxLength);
//// 
////         // 높이값은 안씀
////         dest.y = m_transform.position.y;
//// 
////         // 이동
////         Vector3 pos;
////         pos.x = dest.x;
////         pos.z = dest.z;
////         pos.y = m_transform.position.y + velocity.y;

//        ////////////////////////////////////////////////////////////////////////////////////
//        // new
//        ////////////////////////////////////////////////////////////////////////////////////
//        Vector3 pos;
//        if (Mathf.Abs(force) > 0.0f)
//        {
//            pos = BSpline.Instance.Evaluate(movedLength / BSpline.Instance.maxLength);

//            pos += PathDir() * force;
//            pos.y = m_transform.position.y + velocity.y;

//            movedLength = BSpline.Instance.FindClosetPosition(pos) * BSpline.Instance.maxLength;
//        }
//        else
//        {
//            //이동 거리 보간(0 ~ Path 최대이동거리)
//            movedLength = Mathf.Clamp(movedLength + force, 0.0f, BSpline.Instance.maxLength);

//            // 이동 거리에 따른 Path상의 위치                                        
//            Vector3 dest = BSpline.Instance.Evaluate(movedLength / BSpline.Instance.maxLength);

//            // 높이값은 안씀
//            dest.y = m_transform.position.y;

//            // 이동
//            pos.x = dest.x;
//            pos.z = dest.z;
//            pos.y = m_transform.position.y + velocity.y;
//        }

//        m_transform.position = pos;
//        if (offsetLocal != Vector3.zero)
//        {
//            m_transform.localPosition += offsetLocal;
//        }
//    }

//    public override float Distance(Movement arg)
//    {
//        if (arg is PathMoveController)
//        {
//            return (arg as PathMoveController).movedLength - movedLength;

//        }
//        else
//        {
//            return BSpline.Instance.FindClosetPosition(arg.position) * BSpline.Instance.maxLength - movedLength;
//        }
//    }

//}