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
    }

    public void Attack(GameType.AnimationState state)
    {
        battleMy.Casting(state);
        animation2D.PlayAnimation(state);
    }
    
}
