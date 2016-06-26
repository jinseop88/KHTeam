using UnityEngine;
using System.Collections;

public static class GameType 
{
    //주의!! 무조건 아래로 추가되어야한다... 
    public enum AnimationState
    {
        Skill01,
        Idle,
        Move,
        Jump,
        Dead,

        Projectile,
        Damage,

        Max,
    }
}
