using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
    private new Renderer renderer = null;
    private Vector2 offset = new Vector2(0.0f, 0.0f);
    public Vector2 accelerator = new Vector2(0.01f, 0.0f);

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
        //Debug.Log(offset.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.SetTextureOffset("_MainTex", offset);
        offset += accelerator;
       
    }
}
