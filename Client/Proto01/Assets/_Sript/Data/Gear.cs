using UnityEngine;
using System.Collections;

public class Gear : PartsBase
{

    public override void Initialize()
    {
        base.Initialize();

        m_ePartsType = ePartsType.Gear;
    }

}