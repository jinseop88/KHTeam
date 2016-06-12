using UnityEngine;
using System.Collections;

public class Character : Actor 
{
    void Start()
    {
        Initialize();
    }
    public override void Initialize()
    {
        base.Initialize();

        input = thisObject.AddComponent<KeyboardInput>();

        onDamage = OnDamage;
    }

    public void OnDamage(Actor attacker, SkillImpactInfo skillImpact)
    {

    }
    
}
