//----------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright ?2011-2015 Tasharen Entertainment
//----------------------------------------------

using UnityEngine;

/// <summary>
/// Very basic script that will activate or deactivate an object (and all of its children) when clicked.
/// </summary>

[AddComponentMenu("NGUI/Interaction/Button Activate")]
public class UIButtonActivate : MonoBehaviour
{
    public GameObject target;
    public bool state = true;
    
    //클릭말고 Press이벤트 사용할건지
    public bool m_bUsePress = false;

    void OnClick() { if (target != null && !m_bUsePress) NGUITools.SetActive(target, state); }

    void OnPress(bool bPress) { if (target != null && m_bUsePress) NGUITools.SetActive(target, bPress); }
}