using UnityEngine;
using System.Collections;

/// <summary>
/// Transparent 렌더링 시에 알파 소팅 순서를 정한다
/// 순서를 다르게 정할 경우에 반드시 다른 Material을 사용해야 한다.
/// </summary>
[AddComponentMenu("Rendering/SetRenderQueue")]
[RequireComponent(typeof(Renderer))]
public class SetRenderQueue : MonoBehaviour
{
    public int queue = 1;

    protected void Start() {
        if (!GetComponent<Renderer>() || !GetComponent<Renderer>().sharedMaterial)
            return;

        /// 유니티에서 Transparent 의 queue값이 3000번 이기 때문에 3000을 더한다
        for (int i = 0; i < GetComponent<Renderer>().sharedMaterials.Length; i++)
            GetComponent<Renderer>().sharedMaterials[i].renderQueue = 3000 + queue;
    }

}