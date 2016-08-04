using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour
{
    private new Renderer renderer = null;
    private float offset = 0f;
    public float accelerator = 0.01f;

    // Use this for initialization
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.shader = Shader.Find("Unlit/TransparentOffset");
    }

    // Update is called once per frame
    void Update()
    {
        renderer.material.SetFloat("_Offset", offset);
        offset += accelerator;

        if (offset >= 1f)
            offset = -1f;
    }
}
