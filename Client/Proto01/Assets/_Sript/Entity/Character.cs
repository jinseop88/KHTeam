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
        animation2D = thisObject.GetComponent<Animation2D>();
        animation2D.Initialize();

        movement2D = thisObject.GetComponent<Movement2D>();
        movement2D.Initialize();

        battleMy = thisObject.GetComponent<CharacterBattle>();
        battleMy.Initialize();

        input = thisObject.AddComponent<KeyboardInput>();

        onDamage = OnDamage;
    }

    public void OnDamage(Actor attacker, SkillImpactInfo skillImpact)
    {

    }
    /// <summary>
    /// 방향턴
    /// </summary>
    /// <param name="eDir"></param>
    public void SetDirection(eDirection eDir)
    {
        movement2D.SetRotation(eDir);
    }

    /// <summary>
    /// 이동
    /// </summary>
    public void Move()
    {
        animation2D.OnMove(true);
        movement2D.Move(Vector3.one);
    }

    /// <summary>
    /// 이동멈춤
    /// </summary>
    public void MoveStop()
    {
        animation2D.OnMove(false);
        movement2D.Move(Vector3.zero);
    }

    /// <summary>
    /// 공격
    /// </summary>
    /// <param name="state"></param>
    public void Attack(GameType.AnimationState state)
    {
        battleMy.Casting(state);
        animation2D.OnAttack();
    }

    /// <summary>
    /// 점프
    /// </summary>
    public void Jump()
    {
        animation2D.OnJump();
        movement2D.OnJump();
    }


    

    
    
}
