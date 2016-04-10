using UnityEngine;
using System.Collections;

public enum eBreakType
{
    mtb,
    sadf,

}
public class Break : PartsBase
{

    public override void Initialize()
    {
        base.Initialize();

        m_ePartsType = ePartsType.Break;
    }
}
