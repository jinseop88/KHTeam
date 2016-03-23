using UnityEngine;
using System.Collections;

public class Break : PartsBase
{

    public override void Initialize()
    {
        base.Initialize();

        m_ePartsType = ePartsType.Break;
    }
}
