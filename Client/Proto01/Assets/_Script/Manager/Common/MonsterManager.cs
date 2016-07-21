using UnityEngine;
using System.Collections;

public enum MonsterType
{
    GoblinFire,
}

public class MonsterManager : SingleTon<MonsterManager>
{
    public Monster CreateMonster(MonsterType eMonsterType)
    {
        GameObject objMonster = Resources.Load("Prefabs/Monster/" + eMonsterType.ToString() + "/" + eMonsterType.ToString()) as GameObject;

        GameObject clone = GameObject.Instantiate(objMonster) as GameObject;
        Monster monster = clone.GetComponent<Monster>();

        return monster;
    }
}
