using UnityEngine;
using System.Collections;

/// <summary>
/// 그냥 보여주기만 하는 이펙트
/// </summary>
public class SkillEffectShow : SkillEffectBase
{
    public override void Initialize()
    {
        m_bStart = false;
        thisObject.SetActive(false);
    }

    public override void Reset() 
    {
    }
    protected override void StartEffect() 
    {
        thisObject.SetActive(true);
    }
    protected override void EndEffect() 
    {
        thisObject.SetActive(false);
    }

}
