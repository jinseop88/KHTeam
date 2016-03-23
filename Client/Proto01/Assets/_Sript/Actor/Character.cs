using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour
{
    private int m_nCurrnetLife;
    private int m_nMaxLife;

    private CharacterData m_cCharacterData;
    
    public int currentLife { get { return m_nCurrnetLife; } }
    public int maxLife { get { return m_nMaxLife; } }
    public CharacterData characterData { get { return m_cCharacterData; } }


    public void Initialize(CharacterData CharData)
    {
        m_cCharacterData = new CharacterData();
        m_cCharacterData = CharData;

        m_nCurrnetLife = 0;
        m_nMaxLife = 0;
    }
}
