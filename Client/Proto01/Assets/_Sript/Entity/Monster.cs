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
        animation2D = thisObject.GetComponent<Animation2D>();
        animation2D.Initialize();

        movement2D = thisObject.GetComponent<Movement2D>();
        movement2D.Initialize();

        onDamage = OnDamage;
    }

    public void OnDamage(Actor attacker, SkillImpactInfo skillImpact)
    {
        animation2D.OnDead();

        //죽으면 지워버려
        Invoke("Delete", 2f);
    }
    public void Delete()
    {
        Destroy(thisObject);
    }
}
