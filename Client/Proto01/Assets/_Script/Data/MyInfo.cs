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
    public int insamCount { get; private set; }

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
