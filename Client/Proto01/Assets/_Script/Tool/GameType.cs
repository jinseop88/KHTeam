using UnityEngine;
using System.Collections;

public static class GameType 
{
    //주의!! 무조건 아래로 추가되어야한다... 
    public enum AnimationState
    {
        Idle,
        Move,
        Damaged,
        Dead,

        Skill01,
        Skill02,
        Max,
    }
}
