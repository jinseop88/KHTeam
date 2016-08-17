using UnityEngine;
using System.Collections;

public class MonsterAI : BaseAI
{
    protected override void UpdateAI()
    {
        if (UpdateTarget())
            m_Owner.LookAt(m_Target.thisTransform.position);
    }

    public bool UpdateTarget()
    {
        if (m_Target != null) return true;

        if (IngameManager.Instance.m_myCharacter == null)
            return false;

        m_Target = IngameManager.Instance.m_myCharacter;
        return true;

    }
}
