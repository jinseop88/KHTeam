using UnityEngine;
using System.Collections;

public class MonsterAnimation2D : Animation2D
{
    public override void OnMove(bool bMove)
    {
        // Nothing to do
    }

    public override void OnAttack()
    {
        // Nothing to do
    }

    /// <summary>
    /// 점프
    /// </summary>
    public override void OnJump()
    {
        // Nothing to do
    }

    public override void OnDamage()
    {
        // Nothing to do
    }

    public override void OnDead()
    {
        m_animator.SetTrigger(GameType.AnimationState.Dead.ToString());
    }
}
