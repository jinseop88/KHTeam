using UnityEngine;
using System.Collections;

public class SceneBase : IGameEventListener
{
    protected SceneBase()
    {
        GameEventManager.Register(this);
    }

    public Coroutine StartCourotine(IEnumerator couroutine)
    {
        return SceneManager.Instance.StartCoroutine(couroutine);
    }

    /// <summary>
    /// 씬입장
    /// </summary>
    public virtual void Enter() { }

    /// <summary>
    /// 씬 업데이트
    /// </summary>
    public virtual void SceneUpdate() { }

    /// <summary>
    /// 씬나갈때
    /// </summary>
    public virtual void Exit() { }


    public virtual void HandleEvent(GameEventType gameEventType, params object[] args)
    {

    }

    public void OnGameEvent(GameEventType eventType, params object[] args)
    {
        HandleEvent(eventType, args);
    }

}
