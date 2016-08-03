using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public enum eUIType
{
    Title,
    GameLobby,
    Ingame,
    ChapterSelector,
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
        DontDestroyOnLoad(uiroot);
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

            ///없으면 로드 있으면 셋팅
            Transform target = objmanager.transform.FindChild(((eUIType)i).ToString());
            if(target == null)
            {
                GameObject resourceUI = Resources.Load("Prefabs/UI/UIGame/" + ((eUIType)i).ToString(), typeof(GameObject)) as GameObject;
                findUI.objUI = GameObject.Instantiate(resourceUI) as GameObject;

                findUI.objUI.name = findUI.objUI.name.Replace("(Clone)", "");
                findUI.objUI.transform.parent = objmanager.transform;
                findUI.objUI.transform.localPosition = Vector3.zero;
                findUI.objUI.transform.localScale = Vector3.one;
                findUI.objUI.transform.localRotation = Quaternion.identity;

            }
            else
                findUI.objUI = target.gameObject;

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
