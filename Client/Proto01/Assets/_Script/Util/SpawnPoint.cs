using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour 
{
    public Vector3 position { get { return transform.position; } }
    public Quaternion rotation { get { return transform.rotation; } }

}
