using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Actor : BaseEntity
{
    public float currentHP = 11200f;

    public float maxHP = 200f;

    /// <summary>
    /// 2D전용 애니메이션
    /// </summary>
    public Animation2D animation2D { get; set; }

    /// <summary>
    /// 2D전용 무브먼트
    /// </summary>
    public Movement2D movement2D { get; set; }

    /// <summary>
    /// 입력을 받는 클래스
    /// </summary>
    public InputBase input { get; set; }

    /// <summary>
    /// 캐릭터 전용 배틀
    /// </summary>
    public CharacterBattle battleMy { get; set; }

    /// <summary>
    /// 맞았을대 오는 클래스
    /// </summary>
    public Battle.DamageCallBack onDamage { get; protected set; }

    /// <summary>
    /// AI System
    /// </summary>
    public BaseAI AISystem { get; set; }


    public override void Initialize()
    {
        animation2D = thisObject.GetComponent<Animation2D>();
        animation2D.Initialize();

        movement2D = thisObject.GetComponent<Movement2D>();
        movement2D.Initialize();

        battleMy = thisObject.GetComponent<CharacterBattle>();
        battleMy.Initialize();
    }
    /// <summary>
    /// 방향턴
    /// </summary>
    /// <param name="eDir"></param>
    public virtual void SetDirection(eDirection eDir)
    {
        movement2D.SetRotation(eDir);
    }

    /// <summary>
    /// 대상바라보기
    /// </summary>
    /// <param name="targetPos"></param>
    public void LookAt(Vector3 targetPos)
    {
        eDirection dir = targetPos.x - thisTransform.position.x < 0 ? eDirection.Left : eDirection.Right;

        SetDirection(dir);
    }
    
    // <summary>
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
    
}
