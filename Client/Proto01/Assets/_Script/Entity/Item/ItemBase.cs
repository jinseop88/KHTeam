using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class ItemBase : MonoBehaviour
{
    #region Transform, Gameobject
    protected GameObject m_cachedObject;
    public GameObject thisObject
    {
        get
        {
            if (m_cachedObject == null)
                m_cachedObject = gameObject;
            return m_cachedObject;
        }
    }

    protected Transform m_cachedTransform;
    public Transform thisTransform
    {
        get
        {
            if (m_cachedTransform == null)
                m_cachedTransform = transform;
            return m_cachedTransform;
        }
    }
    #endregion

    protected GameType.ItemType m_itemType;
    protected Vector3 m_spawnDir = Vector3.zero;
    
    public Movement2D movement { get; set; }
    public int value = 15;   //아이템이 가지는 벨류
    #region 내부함수
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            Get();
    }

    private void Spawn()
    {
        m_spawnDir.x = Random.Range(-3f, 3f);
        m_spawnDir.y = Random.Range(10f, 15f);

        movement.SetForce(m_spawnDir);
    }
    #endregion
    
    /// <summary>
    /// 초기화 함수
    /// </summary>
    public virtual void Initialize()
    {
        movement = GetComponent<Movement2D>();

        Spawn();
    }

    /// <summary>
    /// 아이템을 먹었을때 (아이템을 지워주는코드가 항상 있어야한다)
    /// </summary>
    public virtual void Get() { }
}
