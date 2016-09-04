using UnityEngine;
using System.Collections;

public static class GameType 
{
    public enum SkinType
    {
        Basic           = 1,  
        GoodDress       = 2,   
        PinkDress       = 3,
        RoseDress       = 4,
        BlueDress       = 5,
        FlowerDress     = 6,
        PurpleDress     = 7,

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
