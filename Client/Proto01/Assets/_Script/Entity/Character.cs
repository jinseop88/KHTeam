using UnityEngine;
using System.Collections;

public class Character : Actor
{
    public override void Initialize()
    {
        base.Initialize();

        input = thisObject.AddComponent<KeyboardInput>();

        AISystem = thisObject.AddComponent<CharacterAI>();
        AISystem.m_Owner = this;
        AISystem.m_Sight = 15f;
        AISystem.m_LimitDistance = 8f;
		AISystem.m_AtkDelay = 0.7f;
        onDamage = OnDamage;

        //ApplySkin(MyInfo.instance.currentSkin, true);
        ApplySkin(GameType.SkinType.GoodDress, true);
    }

    private void OnDamage(BaseEntity attacker, SkillImpactInfo skillImpact)
    {
        animation2D.OnDamage();
        currentHP -= 20f;

        if (currentHP < 0f)
        {
            animation2D.OnDead();
            Invoke("Delete", 0.5f);
        }
    }

    public void ApplySkin(GameType.SkinType newSkin, bool bForceApply = false)
    {
        if ((!bForceApply && (newSkin == MyInfo.instance.currentSkin)) || newSkin >= GameType.SkinType.Max) return;

        string clipPath = "Prefabs/Character/Animation/" + newSkin.ToString() + "/";
        bool bChanged = false;

        foreach(var animData in animation2D.m_animStateInfo)
        {
            AnimationClip clip = Resources.Load(clipPath + animData.state.ToString()) as AnimationClip;
            
            if(clip != null)
            {
                bChanged = true;
                animData.ChangeClip(clip);
            }
        }
        
        if(bChanged)
        {
            animation2D.Initialize();
            MyInfo.instance.ChangeSkin(newSkin);
        }
    }
    
}
