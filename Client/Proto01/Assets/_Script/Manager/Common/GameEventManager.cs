using UnityEngine;
using System.Collections.Generic;

public enum GameEventType
{
    MonsterDied,
}

public class GameEventManager : SingleTon<GameEventManager>
{
    private List<IGameEventListener> handlers = new List<IGameEventListener>();

    public void Register(IGameEventListener gameEventListener)
    {
        handlers.Add(gameEventListener);
    }

    public void Unregister(IGameEventListener gameEventListener)
    {
        handlers.Remove(gameEventListener);
    }

    public void Notify(GameEventType gameEventType)
    {
        foreach (var handler in handlers)
        {
            handler.OnGameEvent(gameEventType);
        }
    }
}
