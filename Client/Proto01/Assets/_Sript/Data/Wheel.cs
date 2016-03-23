using UnityEngine;
using System.Collections;

public class Wheel : PartsBase
{

    public override void Initialize()
    {
        base.Initialize();

        m_ePartsType = ePartsType.Wheel;
    }
}