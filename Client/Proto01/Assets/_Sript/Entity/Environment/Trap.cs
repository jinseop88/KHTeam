using UnityEngine;
using System.Collections;

public class Trap : BaseEntity 
{
    private SkillImpactInfo m_impactInfo;

    void Start()
    {
        Initialize();
    }

    public override void Initialize()
    {
        base.Initialize();

        m_impactInfo = thisObject.GetComponent<SkillImpactInfo>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            //체력 닳게
            other.gameObject.GetComponent<Character>().onDamage(this, m_impactInfo);
        }
    }	
}
