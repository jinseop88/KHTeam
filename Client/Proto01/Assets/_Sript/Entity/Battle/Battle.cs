using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour 
{
    public delegate void OnDamageCallBack();
    public OnDamageCallBack onDamage;

    protected Actor m_owner;

    public virtual void OnDamege() { }

}
