using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{

    [Tooltip("발사체가 날아갈 거리(미터). 이 거리 이상 날아가면 사라 집니다")]
    public float m_flyingDistance;

    /// <summary>
    /// 터트릴 시간
    /// </summary>
    [Tooltip("터트릴 시간")]
    public float m_timeToExplosion;

    private SkillImpactInfo m_impact;
    //private ProjectileMovement m_movement;
    private bool m_penetrate;
    private Renderer m_renderer;
    private Vector3 m_startPos;
    //private Timer m_timer;

    public Transform thisTransform { private set; get; }
    public GameObject thisObject { private set; get; }

    public void Fire(Actor owner, bool penetrate, Vector3 position, Vector3 direction, Quaternion rotation, float speed, Battle.HitCallBack hit)
    {
        m_penetrate = penetrate;
        m_startPos = position;

        if (thisTransform == null)
            thisTransform = transform;

        thisTransform.position = position;

        //m_movement.SetRotation(rotation);
        //m_movement.SetInputWorld(direction);
        //m_movement.speed = speed;

        //m_impact.owner = owner;
        m_impact.onHit = hit;
        m_impact.Reset();

        thisObject.SetActive(true);
    }


    public void Update()
    {
        //switch (m_type)
        //{
        //    case Type.Fire:
        //if (m_impact.TestImpactSphere() && !m_penetrate)
        //{
        //    //ObjectPoolManager.instance.ReturnGameObject(thisObject);
        //}
        //else if ((thisTransform.position - m_startPos).sqrMagnitude > m_flyingDistance * m_flyingDistance)
        //{
        //    //ObjectPoolManager.instance.ReturnGameObject(thisObject);
        //}
        //break;
        //}
    }

    public void Awake()
    {
        //thisObject = gameObject;
        //thisTransform = transform;
        //m_movement = GetComponent<ProjectileMovement>();
        //m_impact = GetComponentInChildren<SkillImpactInfo>();
        //m_renderer = GetComponentInChildren<Renderer>();
        //m_timer = thisObject.AddComponent<Timer>();
    }
}
