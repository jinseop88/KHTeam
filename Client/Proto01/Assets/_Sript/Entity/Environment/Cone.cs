using UnityEngine;
using System.Collections;

public class Cone : MonoBehaviour 
{
    private Actor m_Target;

    void Awake()
    {
        m_Target = GameObject.FindObjectOfType<Character>();
    }
}
