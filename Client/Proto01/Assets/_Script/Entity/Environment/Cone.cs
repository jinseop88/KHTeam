using UnityEngine;
using System.Collections;

public class Cone : BaseEntity 
{
    public float m_fShakeValue;
    public float m_fSight;

    private Actor m_Target;
    private Vector3 m_firstPos;

    private Rigidbody m_rigidBody;

    private bool m_bStartAction;

    void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
 	    base.Initialize();

        m_Target = GameObject.FindObjectOfType<Character>();
        m_rigidBody = gameObject.GetComponent<Rigidbody>();

        m_firstPos = transform.position;

        m_bStartAction = false;
    }
    void Update()
    {
        if (m_Target !=  null)
        {
            if(!m_bStartAction && Mathf.Abs(m_Target.thisTransform.position.x - m_firstPos.x) < m_fSight)
            {
                m_bStartAction = true;
                StartCoroutine(ShakeNDrop());
            }

            if (Mathf.Abs(m_Target.thisTransform.position.y) > 100)
                Destroy(thisObject);
        }
    }
    IEnumerator ShakeNDrop()
    {
        float fTime = 0.2f;

        while (fTime > 0)
        {
            
            fTime -= Time.deltaTime;
            thisTransform.position = m_firstPos + (Random.insideUnitSphere * m_fShakeValue);
            yield return null;
        }

        m_rigidBody.isKinematic = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            //체력 닳게
            other.gameObject.GetComponent<Character>().onDamage(this, new SkillImpactInfo());
        }
    }	
}
