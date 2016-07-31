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
            Character tempChar = other.gameObject.GetComponent<Character>();

            //체력 닳게
            if (tempChar != null)
                tempChar.onDamage(this, m_impactInfo);
        }
    }	
}
