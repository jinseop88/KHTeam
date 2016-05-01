using UnityEngine;
using System.Collections;

public class AnimTest : MonoBehaviour 
{
    public Character temp;
    void OnGUI()
    {
        if(GUI.Button(new Rect(100,100,100,100),"Skill01"))
        {
            temp.Attack(GameType.AnimationState.Skill1);
        }

        //if (GUI.Button(new Rect(200, 100, 100, 100), "Move"))
        //{
        //    m_animator.SetBool("Move", true);
        //}
    }
}
