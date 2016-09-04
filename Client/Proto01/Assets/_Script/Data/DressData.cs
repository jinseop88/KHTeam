using System.Collections.Generic;


namespace Data
{
    public class Dress
    {
        public int index;

        public string name;
        public string dec;

        public int flowerPrice;
        public int coinPrice;
    }
}
public class DressTable
{
    private static DressTable m_instance;
    public static DressTable instance
    {
        get
        {
            m_instance = new DressTable();

            return m_instance;
        }
    }
    private DressTable()
    {
        MakeDummyData();
    }

    private List<Data.Dress> m_dressList = new List<Data.Dress>();
    public List<Data.Dress> dressList { get { return m_dressList; } }

    private void MakeDummyData()
    {
        m_dressList.Clear(); 

        Data.Dress dress = new Data.Dress();
        dress.index = 1;	dress.name = "Basic";	    dress.dec = "그냥 한복";	        dress.flowerPrice = 0;      dress.coinPrice = 0;
        m_dressList.Add(dress);

        dress = new Data.Dress();
        dress.index = 2;	dress.name = "GoodDress";	dress.dec = "고급진 양반 한복";	    dress.flowerPrice = 100;    dress.coinPrice = 1000;
        m_dressList.Add(dress);

        dress = new Data.Dress();
        dress.index = 3;	dress.name = "PinkDress";	dress.dec = "꽃분홍 한복";	        dress.flowerPrice = 200;    dress.coinPrice = 2000;
        m_dressList.Add(dress);

        dress = new Data.Dress();
        dress.index = 4;	dress.name = "RoseDress";	dress.dec = "오늘은 황진이 한복";	dress.flowerPrice = 600;    dress.coinPrice = 6000;
        m_dressList.Add(dress);

        dress = new Data.Dress();
        dress.index = 5;	dress.name = "BlueDress";	dress.dec = "푸르른 남색한복";	    dress.flowerPrice = 300;    dress.coinPrice = 3000;
        m_dressList.Add(dress);

        dress = new Data.Dress();
        dress.index = 6;	dress.name = "FlowerDress"; dress.dec = "청순한 벚꽃한복";	    dress.flowerPrice = 400;    dress.coinPrice = 4000;
        m_dressList.Add(dress);

        dress = new Data.Dress();
        dress.index = 7;    dress.name = "PurpleDress"; dress.dec = "신비로운 보라한복";    dress.flowerPrice = 500;    dress.coinPrice = 5000;
        m_dressList.Add(dress);
    }
    
}
