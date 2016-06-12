using UnityEngine;
using System.Collections;

public class Trap : MonoBehaviour 
{
    private GameObject m_thisObject;
    private Transform m_thisTansform;

    public GameObject thisObject { get { return m_thisObject; } }
    public Transform thisTransform { get { return m_thisTansform; } }

    void Awake()
    {
        m_thisObject = gameObject;
        m_thisTansform = transform;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Character"))
        {
            //체력 닳게
            other.gameObject.GetComponent<Character>().onDamage
        }
    }	
}
