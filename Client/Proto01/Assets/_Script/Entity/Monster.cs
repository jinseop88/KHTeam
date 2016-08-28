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

    private void OnDamage(Actor attacker, SkillImpactInfo skillImpact)
    {
        animation2D.OnDamage();
        currentHP -= 80f;

        if (currentHP <= 0f && !m_bAlreadDead)
        {
            m_bAlreadDead = true;

            //MakeItem
            GameEventManager.Notify(GameEventType.SpawnItem, Random.Range(0,100), thisTransform.position);

            animation2D.OnDead();
            StartCoroutine(DeadCheck());
        }
    }

    private IEnumerator DeadCheck()
    {
        while (true)
        {
            if (animation2D.IsPlaying(GameType.AnimationState.DeadEnd))
            {
                Delete();
                yield break;
            }

            yield return null;
        }
    }
    public void Delete()
    {
        Destroy(thisObject);
        GameEventManager.Notify(GameEventType.MonsterDied);
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
