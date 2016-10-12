using UnityEngine;
using System.Collections;

public class UI_Quest : UIBase
{
    public UIUnit_Quest[] m_unitQuests = new UIUnit_Quest[6];

    public Vector3 m_vInPos;
    public Vector3 m_vOutPos;

    private Vector3 m_vDestPos;
    private bool m_bSlideAction;

    public override void Initialize()
    {
        base.Initialize();

        m_vDestPos = m_vInPos;
        m_bSlideAction = true;

        for(int i = 0; i < QuestTable.instance.questList.Count; i++)
        {
            m_unitQuests[i].SetData(QuestTable.instance.questList[i]);
        }

    }

    public void ClickSlide()
    {
        //나올때
        if (m_vDestPos == m_vInPos)
        {
            m_vDestPos = m_vOutPos;
        }
        else
        {
            //들어갈때
            m_vDestPos = m_vInPos;

        }

        if (!m_bSlideAction)
            m_bSlideAction = true;
    }

    private void Update()
    {
        if (m_bSlideAction)
        {
            thisTransform.localPosition = Vector3.Lerp(thisTransform.localPosition, m_vDestPos, Time.deltaTime * 5f);

            if (Vector3.Distance(thisTransform.localPosition, m_vDestPos) < 0.1f)
            {
                m_bSlideAction = false;
                thisTransform.localPosition = m_vDestPos;
            }
        }
    }
}
