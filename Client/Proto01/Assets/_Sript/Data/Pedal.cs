using UnityEngine;
using System.Collections;

public class Pedal : PartsBase
{

    public override void Initialize()
    {
        base.Initialize();

        m_ePartsType = ePartsType.Pedal;
    }
}