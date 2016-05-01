using UnityEngine;
using System.Collections;

/// <summary>
/// 그냥 보여주기만 하는 이펙트
/// </summary>
public class SkillEffectShow : SkillEffectBase
{
    public override void Initialize()
    {
    }

    public override void Casting() 
    {
        thisObject.SetActive(true);
    }
    public override void Cancel() 
    {
        thisObject.SetActive(false);
    }
    public override void Reset() 
    {
        thisObject.SetActive(false);
    }
}
