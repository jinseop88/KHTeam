using UnityEngine;
using System.Collections;

public class UI_DressRoom : UIBase
{
    public UIScrollView m_scrollView;
    public UIWrapContent m_wrapContent;

    public Transform m_trPreviewObject;
    private Character m_previewCharacter;

    public Vector3 m_vInPos;
    public Vector3 m_vOutPos;

    private Vector3 m_vDestPos;
    private bool m_bSlideAction;

    public override void Initialize()
    {
        base.Initialize();

        m_wrapContent.minIndex = DressTable.instance.dressList.Count == 1 ? -1 : 0;
        m_wrapContent.maxIndex = DressTable.instance.dressList.Count - 1;
        m_wrapContent.onInitializeItem = OnUpdateItem;
        m_wrapContent.ResetScrollView();

        if (m_previewCharacter != null) return;

        m_previewCharacter = CharacterManager.Instance.CreateCharacter();
        m_previewCharacter.Initialize();

        m_previewCharacter.thisTransform.parent = m_trPreviewObject;
        m_previewCharacter.thisTransform.localPosition = Vector3.zero;
        m_previewCharacter.thisTransform.localScale = Vector3.one;
        m_previewCharacter.thisTransform.localRotation = Quaternion.identity;

        m_previewCharacter.movement2D.enabled = false;
        m_previewCharacter.Move();
      
        m_vDestPos = m_vInPos;
        m_bSlideAction = true;

    }

    private void OnUpdateItem(GameObject obj, int wrapIndex, int realIndex)
    {
        if (realIndex < 0 || realIndex >= DressTable.instance.dressList.Count) return;

        UIUnit_Dress dressUI = obj.GetComponent<UIUnit_Dress>();

        if(dressUI != null)
        {
            dressUI.SetData(DressTable.instance.dressList[realIndex]);
        }
    }

    

    public void ClickSlide()
    {
        m_vDestPos = m_vDestPos == m_vInPos ? m_vOutPos : m_vInPos;

        if(!m_bSlideAction)
            m_bSlideAction = true;
    }

    private void Update()
    {
        if(m_bSlideAction)
        {
            thisTransform.localPosition = Vector3.Lerp(thisTransform.localPosition, m_vDestPos, Time.deltaTime * 5f);

            if(Vector3.Distance(thisTransform.localPosition, m_vDestPos) < 0.1f)
            {
                m_bSlideAction = false;
                thisTransform.localPosition = m_vDestPos;
            }
        }
    }

}
