using UnityEngine;
using System.Collections;

public class GoodSystem : UIBase
{
    /// <summary>
    /// 재화 개수 초기화(코인, 꽃, 산삼)
    /// </summary>
    public static int m_CoinCount = 0;
    public static int m_FlowerCount = 0;
    public static int m_SansamCount = 0;

    //protected Actor m_owner;

    /// <summary>
    /// 재화 UI 생성
    /// </summary>
    public UICoin_System m_uiCoinSystem;
    public UIFlower_System m_uiFlowerSystem;
    public UISansam_System m_uiSansamSystem;

    /// <summary>
    /// 재화 수집 bool값 선언
    /// </summary>
    bool Coin_collect;
    bool Flower_collect;
    bool Sansam_collect;


    public override void Initialize()
    {
        /// <summary>
        /// PlayerPrefs에 초기값 저장
        /// </summary>
        m_CoinCount = PlayerPrefs.GetInt("Coin");
        m_FlowerCount = PlayerPrefs.GetInt("Flower");
        m_SansamCount = PlayerPrefs.GetInt("Sansam");

        /// <summary>
        /// PlayerPrefs 초기화함수
        /// </summary>
        //PlayerPrefs.DeleteAll();


        /// <summary>
        /// Coin을 get했을때 받아올 bool값을 반환하는 오브젝트의 스크립트 선언
        /// </summary>
        GameObject.Find("Character").GetComponent("Character");

        

        StartCoroutine(GetGoods());
        //StartCoroutine(IncreaseFlowerCount());
        //m_owner = thisObject.GetComponent<Character>();


    }    

    void Start()
    {
        Initialize();

        /// <summary>
        /// bool값 가져오기
        /// </summary>
        //Coin_collect = thisObject.GetComponent<Character>().getCoin;
        //Flower_collect = thisObject.GetComponent<Character>().getFlower;
        //Sansam_collect = thisObject.GetComponent<Character>().getSansam;
    }

    IEnumerator GetGoods()
    {
        
        while (true)
        {
            /// <summary>
            /// Character과 충돌했을때 bool값을 true로 받아옴
            /// </summary>
            if (Coin_collect == true){
                m_uiCoinSystem.coinCount = m_uiCoinSystem.coinCount + 1;
                Coin_collect = false;
            }
            if (Flower_collect == true){
                m_uiFlowerSystem.FlowerCount = m_uiFlowerSystem.FlowerCount + 1;
                Flower_collect = false;
            }
            if (Sansam_collect == true){
                m_uiSansamSystem.SansamCount = m_uiSansamSystem.SansamCount + 1;
                Sansam_collect = false;
            } 
            

            return null;
        }

    }


}
