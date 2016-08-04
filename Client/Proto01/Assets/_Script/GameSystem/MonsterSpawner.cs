using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{
    public void Spawn(Monster monster, int count)
    {
        for (int i = 0; i != count; ++i)
        {
            Instantiate(monster.thisObject, transform.position, transform.rotation);
        }
    }
}
