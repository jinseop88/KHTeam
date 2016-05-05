﻿using UnityEngine;
using System.Collections;

public class KeyboardInput : InputBase 
{
    public Character character { get { return (Character)m_owner; } }
	void Update () 
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            character.Attack(GameType.AnimationState.Skill01);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            character.SetDirection(eDirection.Left);
            character.Move();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            character.SetDirection(eDirection.Right);
            character.Move();
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            character.MoveStop();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            character.Jump();
        }
	}
}
