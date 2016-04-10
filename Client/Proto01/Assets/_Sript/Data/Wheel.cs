using UnityEngine;
using System.Collections;

public class Wheel : PartsBase
{
    /// <summary>
    /// 바퀴 반지름
    /// </summary>
    private float m_fRadius = 0.5f;

    /// <summary>
    /// 바퀴 둘레
    /// </summary>
    public float circleMeter { get { return m_fRadius * CycleMath.PI * 2f; } }
    

    public override void Initialize()
    {
        base.Initialize();

        m_ePartsType = ePartsType.Wheel;

    }
}