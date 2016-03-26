using UnityEngine;
using System.Collections;

public class followcamera : MonoBehaviour {

    public GameObject target;
    Vector3 prevPos;
	void Start()
    {
        prevPos = transform.position;
    }
	void Update () 
    {
        //target
        transform.position = target.transform.position + prevPos;

	}
}
