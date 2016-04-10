using UnityEngine;
using System.Collections;

public class Gear : PartsBase
{
    /// <summary>
    /// 페달 한바퀴돌리는데 걸리는시간.
    /// </summary>
    public float pedalTime { get { return 1f; } }

    /// <summary>
    /// 페달 한바퀴에 몇바퀴도는지
    /// </summary>
    public int runCountPerPedal { get { return 8; } }

    public override void Initialize()
    {
        base.Initialize();

        m_ePartsType = ePartsType.Gear;
    }

}