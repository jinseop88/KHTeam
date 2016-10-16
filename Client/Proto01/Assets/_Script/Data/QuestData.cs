using System.Collections.Generic;

namespace Data
{
    public class Quest
    {
        public int index;

        public string name;
        public string dec;

        public int prcessTime;//분

        public int immediatePrice;
        public int reward;
    }
}

public enum QuestType
{
	Soul	 = 1,
	Baby,
	Ghost,
	DeathAngel,
	Goblin,
	Gumiho
}

public class QuestTable
{
    private static QuestTable m_instance;
    public static QuestTable instance
    {
        get
        {
            m_instance = new QuestTable();

            return m_instance;
        }
    }
    private QuestTable()
    {
        MakeDummyData();
    }

    private List<Data.Quest> m_questList = new List<Data.Quest>();
    public List<Data.Quest> questList { get { return m_questList; } }

    private void MakeDummyData()
    {
        m_questList.Clear();

        Data.Quest quest = new Data.Quest();
        quest.index = 1; quest.name = "혼령 안내하기"; quest.dec = "혼령 안내하기";
        quest.prcessTime = 10; quest.immediatePrice = 100; quest.reward = 50;
        m_questList.Add(quest);

        quest = new Data.Quest();
        quest.index = 2; quest.name = "애기귀신 놀아주기"; quest.dec = "애기귀신 놀아주기";
        quest.prcessTime = 30; quest.immediatePrice = 100; quest.reward = 1000;
        m_questList.Add(quest);

        quest = new Data.Quest();
        quest.index = 3; quest.name = "잡귀신 떨치기"; quest.dec = "잡귀신 떨치기";
        quest.prcessTime = 70; quest.immediatePrice = 200; quest.reward = 2000;
        m_questList.Add(quest);

        quest = new Data.Quest();
        quest.index = 4; quest.name = "저승사자 돕기"; quest.dec = "저승사자 돕기";
        quest.prcessTime = 50; quest.immediatePrice = 600; quest.reward = 6000;
        m_questList.Add(quest);

        quest = new Data.Quest();
        quest.index = 5; quest.name = "도깨비 혼내주기"; quest.dec = "도깨비 혼내주기";
        quest.prcessTime = 90; quest.immediatePrice = 300; quest.reward = 3000;
        m_questList.Add(quest);

        quest = new Data.Quest();
        quest.index = 6; quest.name = "구미호 잡기"; quest.dec = "구미호 잡기";
        quest.prcessTime = 110; quest.immediatePrice = 400; quest.reward = 4000;
        m_questList.Add(quest);
    }
}
