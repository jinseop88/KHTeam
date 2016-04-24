using UnityEngine;
using System.Collections;

public enum eUIType
{
    Title,
    GameLobby,
    Game,
    Max,
}
public class UIManager : SingleTon<UIManager>
{
    private const string m_szResourcePath = "/Asset/Resource/Prefabs/UI";
    public void Initialize()
    {
        GameObject uiroot = GameObject.Find("UI Root");

        //UIManager만들어준다
        GameObject objmanager = new GameObject("UIManager");

        objmanager.transform.parent = uiroot.transform;
        objmanager.transform.localPosition = Vector3.zero;
        objmanager.transform.localScale = Vector3.one;
        objmanager.transform.localRotation = Quaternion.identity;
    }

    public void OpenUI(eUIType eType)
    {
        GameObject resourse = Resources.Load(m_szResourcePath + "/UIGame/" + eType.ToString()) as GameObject;
        GameObject target = Instantiate(resourse, Vector3.zero, Quaternion.identity) as GameObject;

        target.transform.parent = Instance.transform;
    }
}
