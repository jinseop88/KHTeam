using UnityEngine;
using System.Collections;

public class UIPage_Quest : UIBase
{
	public UIUnit_Quest[] m_unitQuests = new UIUnit_Quest[6];

	public override void Initialize ()
	{
		base.Initialize ();

		for(int i = 0; i < QuestTable.instance.questList.Count; i++)
		{
			m_unitQuests[i].SetData(QuestTable.instance.questList[i]);
		}
	}
}
