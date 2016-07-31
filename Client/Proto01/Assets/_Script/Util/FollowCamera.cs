using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
    public Transform m_target;

    private Vector3 m_Offset;


    //void Start()
    //{
    //    m_Offset = transform.position;
    //}
    void Update()
    {
        if(m_target != null)
        {
            Vector3 newPos = transform.position;
            newPos.x = m_target.position.x;

            transform.position = newPos;
            //transform.LookAt(m_target);
        }
    }
}
