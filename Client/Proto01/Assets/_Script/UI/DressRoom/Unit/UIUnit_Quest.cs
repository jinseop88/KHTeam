using UnityEngine;
using System.Collections;

public class UIUnit_Quest : UIBase
{
    public UISprite m_spQuestThumb;

    public UILabel m_lbQuestName;
    public UILabel m_lbimmediatePrice;
    public UILabel m_lbReward;

    public UIProgressBar m_barQuestProgress;
    public UILabel m_lbRemainTime;

    public Data.Quest quest { get; set; }

    private System.DateTime m_tStartTime;

    public void ClickImmediateComplete()
    {
        if(MyInfo.instance.coinCount > quest.immediatePrice)
        {
            //차감후 완료
            MyInfo.instance.AddCoin(-quest.immediatePrice);

            CompleteQuest();
        }
    }

    public void SetData(Data.Quest questData)
    {
        quest = questData;

		m_spQuestThumb.spriteName = "Quest_" + ((QuestType)questData.index).ToString();

        m_lbQuestName.text = quest.name;
        m_lbimmediatePrice.text = "즉시완료\n옆전 : " + quest.immediatePrice.ToString();
        m_lbReward.text = "보상\n꽃 : " + quest.reward.ToString();

        m_tStartTime = MyInfo.instance.GetQuestStartTime(quest.index);

    }

    private void CompleteQuest()
    {
        //보상처리
        MyInfo.instance.AddFlower(quest.reward);

        MyInfo.instance.SetQuestStartTime(quest.index);

		m_tStartTime = System.DateTime.UtcNow;///MyInfo.instance.GetQuestStartTime(quest.index);
    }

    private void Update()
    {
        if(quest != null)
        {
            float remainTime = (float)(System.DateTime.UtcNow - m_tStartTime).TotalSeconds;

            //자동갱신
            if (remainTime > quest.prcessTime * 60f)
                CompleteQuest();

            int min = (int)(quest.prcessTime * 60 - remainTime) / 60;
            int sec = (int)(quest.prcessTime * 60 - remainTime) % 60;
            m_lbRemainTime.text = min+"분" + sec +"초";
            m_barQuestProgress.value = remainTime / quest.prcessTime / 60f;
        }

    }
}
