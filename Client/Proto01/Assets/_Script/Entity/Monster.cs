using UnityEngine;
using System.Collections;

public class Monster : Actor 
{
    MonsterAI AISystem;

    void Start()
    {
        Initialize();
    }
    public override void Initialize()
    {
        base.Initialize();

        onDamage = OnDamage;

        AISystem = thisObject.AddComponent<MonsterAI>();
        AISystem.m_Owner = this;
        //AISystem.m_Target;
        AISystem.m_Sight = 5f;
        AISystem.m_LimitDistance = 3f;
        AISystem.m_AtkDelay = 2f;

        AISystem.AIOn();
    }

    private void OnDamage(BaseEntity attacker, SkillImpactInfo skillImpact)
    {
        animation2D.OnDamage();
        currentHP -= 80f;

        if(currentHP <= 0f)
        {
            animation2D.OnDead();
            Invoke("Delete", 0.5f);
        }
    }
    public void Delete()
    {
        Destroy(thisObject);
    }

}
