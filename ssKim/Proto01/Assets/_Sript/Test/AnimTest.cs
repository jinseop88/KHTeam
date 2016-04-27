using UnityEngine;
using System.Collections;

public class AnimTest : MonoBehaviour 
{
    private Animator m_animator;
    void Start()
    {
        m_animator = gameObject.GetComponent<Animator>();
    }
    void OnGUI()
    {
        if(GUI.Button(new Rect(100,100,100,100),"Attack"))
        {
            m_animator.SetTrigger("Attack");
            m_animator.SetBool("Move", false);
        }

        if (GUI.Button(new Rect(200, 100, 100, 100), "Move"))
        {
            m_animator.SetBool("Move", true);
        }
    }
}
