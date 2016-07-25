using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IngameManager : SingleTon<IngameManager>
{
    public Character m_myCharacter;

    public List<Monster> m_monsterList = new List<Monster>();

}
