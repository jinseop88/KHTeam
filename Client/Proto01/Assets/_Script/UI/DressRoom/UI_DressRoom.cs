using UnityEngine;
using System.Collections;

public class UI_DressRoom : UIBase
{  
	public UIPage_Quest m_pageQuest;
	public UIPage_Dress m_pageDress;

    public Vector3 m_vInPos;
    public Vector3 m_vOutPos;

    private Vector3 m_vDestPos;
    private bool m_bSlideAction;

    public override void Initialize()
    {
        base.Initialize();       
      
        m_vDestPos = m_vInPos;
        m_bSlideAction = true;

		m_pageQuest.Initialize ();
		m_pageDress.Initialize ();

		m_pageQuest.SetActive(false);
		m_pageDress.SetActive(true);
    }    

	public void ClickQuestTab()
	{
		m_pageQuest.SetActive(true);
		m_pageDress.SetActive(false);
	}

	public void ClickDressTab()
	{
		m_pageQuest.SetActive(false);
		m_pageDress.SetActive(true);
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

			m_pageDress.ApplyMyCharacter ();

        }

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
