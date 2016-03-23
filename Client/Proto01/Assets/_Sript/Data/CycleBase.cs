using UnityEngine;
using System.Collections;

public class CycleBase : MonoBehaviour 
{

    /// <summary>
    /// 자전거를 구성하는 파츠들
    /// </summary>
    protected PartsBase[] m_cParts = new PartsBase[(int)ePartsType.Max];
}
