using UnityEngine;
using System.Collections;

public class Monster : Actor 
{
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

            // How can I catch when the dead animation is finished?
            Invoke("Delete", 3.0f);
        }
    }

    public void Delete()
    {
        Destroy(thisObject);
    }

    void OnEnable()
    {
        IngameManager.Instance.m_monsterList.Add(this);
    }

    void OnDisable()
    {
        IngameManager.Instance.m_monsterList.Remove(this);
    }
}
