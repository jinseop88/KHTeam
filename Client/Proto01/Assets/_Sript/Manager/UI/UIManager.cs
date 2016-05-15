using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum eUIType
{
    Title,
    //GameLobby,
    //Ingame,
    //StageSelector,
    Max,
}

public struct UIData
{
    public bool bPopup;
    public GameObject objUI;
}
public class UIManager : SingleTon<UIManager>
{
    private Dictionary<eUIType, UIData> m_UIDic = new Dictionary<eUIType, UIData>();

    private const string m_szResourcePath = "/Asset/Resource/Prefabs/UI";
    
    public void Initialize()
    {
        GameObject uiroot = GameObject.Find("UI Root");

        //UIManager만들어준다
        GameObject objmanager = uiroot.transform.FindChild("UIManager").gameObject;
        if (objmanager == null)
            objmanager = new GameObject("UIManager");

        objmanager.transform.parent = uiroot.transform;
        objmanager.transform.localPosition = Vector3.zero;
        objmanager.transform.localScale = Vector3.one;
        objmanager.transform.localRotation = Quaternion.identity;

        //모든 UI등록
        for(int i = 0 ; i < (int)eUIType.Max ; i++)
        {
            UIData findUI = new UIData();

            findUI.objUI = objmanager.transform.FindChild(((eUIType)i).ToString()).gameObject;
            findUI.bPopup = false;
            findUI.objUI.SetActive(false);

            if (!m_UIDic.ContainsKey((eUIType)i))
                m_UIDic.Add((eUIType)i, findUI);
        }
    }

    public T GetUI<T>(eUIType eType) where T: UIBase
    {
        return (T)(m_UIDic[eType].objUI.GetComponent<UIBase>());
    }
    /// <summary>
    /// UI 여는 함수
    /// </summary>
    /// <param name="eType"></param>
    public void OpenUI(eUIType eType) 
    {
        UIData uiData = m_UIDic[eType];

        uiData.objUI.SetActive(true);
    }

    /// <summary>
    /// UI닫는 함수
    /// </summary>
    /// <param name="eType"></param>
    public void CloseUI(eUIType eType)
    {
        UIData uiData = m_UIDic[eType];

        uiData.objUI.SetActive(false);
    }
}
