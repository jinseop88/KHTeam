using UnityEngine;
using System.Collections;

public static class GameType 
{
    public enum SkinType
    {
        Basic,
        GoodDress,
        RoseDress,

        Max,
    }

    public enum ItemType
    {
        Coin,
        Flower,
        Insam,
        Max,
    }

    //주의!! 무조건 아래로 추가되어야한다... 
    public enum AnimationState
    {
        Idle,
        Move,
        Damaged,
        Dead,

        Attack,

        DeadEnd,
        Max,
    }
}
