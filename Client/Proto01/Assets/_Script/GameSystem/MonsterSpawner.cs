using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{
    public void Spawn(Monster monster, int count, SpawnPoint spawnPoint)
    {
        for (int i = 0; i != count; ++i)
        {
            Instantiate(monster.thisObject, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
