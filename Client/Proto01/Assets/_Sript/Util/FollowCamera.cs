using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour 
{
    public Transform m_target;

    private Vector3 m_Offset;


    void Start()
    {
        m_Offset = transform.position;
    }
    void Update()
    {
        if(m_target != null)
        {
            transform.position = m_Offset + m_target.position;
            transform.LookAt(m_target);
        }
    }
}
