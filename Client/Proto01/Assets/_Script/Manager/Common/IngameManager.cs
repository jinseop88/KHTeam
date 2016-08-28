using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IngameManager : SingleTon<IngameManager>
{
    public Character m_myCharacter;

    public List<Monster> m_monsterList = new List<Monster>();


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            GameEventManager.Instance.Notify(GameEventType.Click_Screen);
    }
}
