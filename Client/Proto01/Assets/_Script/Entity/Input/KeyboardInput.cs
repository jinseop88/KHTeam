using UnityEngine;
using System.Collections;

public class KeyboardInput : InputBase 
{
    //public Character character { get { return (Character)m_owner; } }

    public Actor character { get { return (Actor)m_owner; } }
	void Update () 
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            character.Attack(GameType.AnimationState.Projectile);
        }
	}
}
