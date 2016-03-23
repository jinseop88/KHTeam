using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour 
{
    private int m_nUserID;

    private Character m_Character;
    private List<Card> m_CardList = new List<Card>();

    public int userID { get { return m_nUserID; } }
    public Character character { get { return m_Character; } }
    public List<Card> cardList { get { return m_CardList; } }

    public void Initialize(int nID)
    {
        m_nUserID = nID;
    }
    public void SetCharacterData(CharacterData CharData)
    { 
    }
    public void SetCardList(List<CardData> CardList)
    {
    }
}
