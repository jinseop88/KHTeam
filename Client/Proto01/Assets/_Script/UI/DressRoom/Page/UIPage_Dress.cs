using UnityEngine;
using System.Collections;

public class UIPage_Dress : UIBase 
{
	public UIScrollView m_scrollView;
	public UIWrapContent m_wrapContent;
	public Transform m_trPreviewObject;

	private Character m_previewCharacter;
	private GameType.SkinType m_ePreviewSkinType;

	public override void Initialize()
	{
		base.Initialize();

		m_ePreviewSkinType = GameType.SkinType.Max;

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

		m_previewCharacter.thisObject.GetComponent<Magic> ().enabled = false;
		m_previewCharacter.movement2D.enabled = false;
		m_previewCharacter.Move();
	}

	private void OnEnable()
	{
		if(m_previewCharacter != null)
			m_previewCharacter.Move();

		if(m_wrapContent != null)
			m_wrapContent.ResetScrollView();
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

	public void PreviewCharacterApplySkin(GameObject obj)
	{
		UIUnit_Dress ui = obj.GetComponent<UIUnit_Dress>();

		if(ui != null)
		{
			GameType.SkinType newSkinType = (GameType.SkinType)ui.dress.index;

			if(m_ePreviewSkinType != newSkinType)
			{
				m_ePreviewSkinType = newSkinType;
				m_previewCharacter.ApplySkin(newSkinType, true);
			}
		}
	}

	public void ApplyMyCharacter()
	{
		//수정이 되었다면
		if (m_ePreviewSkinType != GameType.SkinType.Max)
			GameEventManager.Notify(GameEventType.ChangeSkin, (int)m_ePreviewSkinType);
	}
}
