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
    }

    private void OnDamage(BaseEntity attacker, SkillImpactInfo skillImpact)
    {
        animation2D.OnDamage();
        currentHP -= 100f;

        if(currentHP < 0f)
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
