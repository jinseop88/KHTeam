using UnityEngine;
using System.Collections;

public class FollowBackground : MonoBehaviour 
{
    private Vector3 m_offset;

    ///캐릭터를 따라다니도록하자
    private Transform m_target;
    private bool m_bSetOffset;

    private void Update()
    {
        if (!m_bSetOffset && m_target == null)
        {
            m_target = GameObject.FindObjectOfType<Character>().thisTransform;

            if(m_target != null)
            {
                m_offset = transform.position - m_target.position;
                m_bSetOffset = true;
            }
        }

        if (m_bSetOffset)
            transform.position = m_offset + m_target.position;
    }
}
