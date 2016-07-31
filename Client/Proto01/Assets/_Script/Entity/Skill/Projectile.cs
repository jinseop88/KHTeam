using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    public float m_flyingDistance;

    private SkillImpactInfo m_impact;
    private Renderer m_renderer;
    private Vector3 m_startPos;
    private Vector3 m_dir;

    public Transform thisTransform { private set; get; }
    public GameObject thisObject { private set; get; }

    public void Fire(Actor owner, Vector3 position, Vector3 direction, Quaternion rotation, float speed, Battle.HitCallBack hit)
    {
        m_impact.Initialize();
        m_startPos = position;
        m_dir = direction * speed;

        if (thisTransform == null)
            thisTransform = transform;

        thisTransform.position = position;
        thisTransform.rotation = rotation;

        m_impact.owner = owner;
        m_impact.onHit = hit;
        m_impact.Reset();

        thisObject.SetActive(true);
    }

    public void Update()
    {
        //이동
        thisTransform.position += m_dir * Time.deltaTime;

        if (m_impact.TestImpactSphere())
        {
            Destroy(thisObject);
        }
        else if ((thisTransform.position - m_startPos).sqrMagnitude > m_flyingDistance * m_flyingDistance)
        {
            Destroy(thisObject);
        }
    }

    public void Awake()
    {
        thisObject = gameObject;
        thisTransform = transform;
        m_impact = GetComponentInChildren<SkillImpactInfo>();
        m_impact.Initialize();
        m_renderer = GetComponentInChildren<Renderer>();
    }
}
