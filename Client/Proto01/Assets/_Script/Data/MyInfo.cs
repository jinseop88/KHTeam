using UnityEngine;
using System.Collections;

/// <summary>
/// 내정보 관련 클래스 
/// 추후 DB화 한다면 
/// 이클래스의 PlayerPrefs부분을 DB화 하면됨
/// </summary>
public class MyInfo
{
    #region instance
    private static MyInfo m_instance;

    public static MyInfo instance 
    {
        get 
        {
            if(m_instance == null)
                m_instance = new MyInfo();

            return m_instance;
        }
    }

    MyInfo()
    {
        coinCount = PlayerPrefs.GetInt("CoinCount", 0);
        insamCount = PlayerPrefs.GetInt("InsamCount", 0);
        flowerCount = PlayerPrefs.GetInt("FlowerCount", 0);
        monsterKillCount = PlayerPrefs.GetInt("MonsterKillCount", 0);

        currentSkin = (GameType.SkinType)PlayerPrefs.GetInt("CurrentSkin", 0);
    }
    #endregion

    /// <summary>
    /// 코인갯수
    /// </summary>
    public int coinCount { get; private set; }

    /// <summary>
    /// 인삼갯수
    /// </summary>
    public int insamCount { get; set; }

    /// <summary>
    /// 꽃갯수
    /// </summary>
    public int flowerCount { get; private set; }

    /// <summary>
    /// 마지막 장착 스킨
    /// </summary>
    public GameType.SkinType currentSkin { get; private set; }

    /// <summary>
    /// 몬스터 잡은수
    /// </summary>
    public int monsterKillCount { get; private set; }


    public void SetQuestStartTime(int index)
    {
        System.DateTime now = System.DateTime.UtcNow;
        string time = string.Empty;
        time = now.Year + "-";
        time += now.Month + "-";
        time += now.Day + "-";
        time += now.Hour + "-";
        time += now.Minute + "-";
        time += now.Second + "-";
        time += now.Millisecond;

        PlayerPrefs.SetString("QuestStartTime_" + index, time);
    }

    public System.DateTime GetQuestStartTime(int index)
    {
		string timeStr = PlayerPrefs.GetString ("QuestStartTime_" + index, "0");
		if (timeStr == "0")
			return System.DateTime.UtcNow;
		
        string[] times = PlayerPrefs.GetString("QuestStartTime_" + index, "1-1-1-1-1-1-1").Split('-');

        int year = int.Parse(times[0]);
        int month = int.Parse(times[1]);
        int day = int.Parse(times[2]);
        int hour = int.Parse(times[3]);
        int minute = int.Parse(times[4]);
        int second = int.Parse(times[5]);
        int millisecond = int.Parse(times[6]);



        return new System.DateTime(year, month, day, hour, minute, second, millisecond);
    }
    #region 셋팅 함수
    /// <summary>
    /// 사용시 -값으로 Add한다
    /// </summary>
    /// <param name="addCoin"></param>
    public void AddCoin(int addCoin)
    {
        coinCount += addCoin;
        PlayerPrefs.SetInt("CoinCount", coinCount);
    }

    /// <summary>
    /// 사용시 -값으로 Add한다
    /// </summary>
    /// <param name="addInsam"></param>
    public void AddInsam(int addInsam)
    {
        insamCount += addInsam;
        PlayerPrefs.SetInt("InsamCount", insamCount);
    }

    /// <summary>
    /// 사용시 -값으로 Add한다
    /// </summary>
    /// <param name="addFlower"></param>
    public void AddFlower(int addFlower)
    {
        flowerCount += addFlower;
        PlayerPrefs.SetInt("FlowerCount", flowerCount);
    }

    /// <summary>
    /// 바꿀 스킨 타입 (밖에서 확인 절차 다끝나고 저장만 한다)
    /// </summary>
    /// <param name="changed"></param>
    public void ChangeSkin(GameType.SkinType changed)
    {
        if (currentSkin != changed)
        {
            currentSkin = changed;
            PlayerPrefs.SetInt("CurrentSkin", (int)currentSkin);
        }
    }

    /// <summary>
    /// 몬스터를 죽였다
    /// </summary>
    /// <param name="addMonsterKill"></param>
    public void AddMonsterKill(int addMonsterKill)
    {
        monsterKillCount += addMonsterKill;
        PlayerPrefs.SetInt("MonsterKillCount", monsterKillCount);
    }
    #endregion

}


