using UnityEngine;
using System.Collections;


public enum ePartsType
{ 
    Handle,
    Frame,
    Break,
    Gear,
    Pedal,
    Saddle,
    Wheel,
    Max,
}


public class PartsBase 
{
    /// <summary>
    /// 파츠의 타입
    /// </summary>
    protected ePartsType m_ePartsType;

    /// <summary>
    /// 파츠의 질량
    /// </summary>
    protected float m_fMass;

    /// <summary>
    /// 파츠의 강도
    /// </summary>
    protected float m_fStrong;

    public virtual void Initialize()
    {
         
    }
}
