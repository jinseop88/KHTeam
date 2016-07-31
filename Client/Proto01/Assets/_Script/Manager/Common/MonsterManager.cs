using UnityEngine;
using System.Collections.Generic;

public enum MonsterType
{
    GoblinFire,
    Dokebi1,
    Dokebi2,
    Bird,
    Boss1,
    Boss2,
}

public class MonsterManager : SingleTon<MonsterManager>
{
    Dictionary<MonsterType, Monster> monsters = new Dictionary<MonsterType, Monster>();

    void Awake()
    {
        foreach (MonsterType monsterType in System.Enum.GetValues(typeof(MonsterType)))
        {
            GameObject gameObject = Resources.Load("Prefabs/Monster/" + monsterType.ToString() + "/" + monsterType.ToString()) as GameObject;
            monsters[monsterType] = gameObject.GetComponent<Monster>();
        }
    }

    public Monster GetNextMonster()
    {
        System.Array enums = System.Enum.GetValues(typeof(MonsterType));
        MonsterType monsterType = (MonsterType)enums.GetValue(Random.Range(0, enums.Length));

        return monsters[monsterType];
    }
}
