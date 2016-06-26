using UnityEngine;
using System.Collections;

public abstract class SceneBase
{
    public Coroutine StartCourotine(IEnumerator couroutine)
    {
        return SceneManager.Instance.StartCoroutine(couroutine);
    }
    /// <summary>
    /// 업데이트
    /// </summary>
    public abstract void Update();

    /// <summary>
    /// 다시시작
    /// </summary>
    public abstract void Restart();

    /// <summary>
    /// 씬나갈때
    /// </summary>
    public abstract void Terminate();

    /// <summary>
    /// 씬입장
    /// </summary>
    public abstract void Enter();
   
    public virtual void Exit()
    {
        Terminate();
    }


}
