using UnityEngine;
using System.Collections;

public class CharacterSpawnPoint : MonoBehaviour 
{
    public Vector3 position { get; private set; }
    public Quaternion rotation { get; private set; }
    void Awake()
    {
        position = transform.position;
        rotation = transform.rotation;
    }
}
