using UnityEngine;
using System.Collections.Generic;

public enum GameEventType
{
    SpawnItem,

    MonsterDied,

    UpdateMoveDistance,

    ClickScreen,

    CastMagic,

    ChangeSkin,
}

public static class GameEventManager
{
    private static List<IGameEventListener> handlers = new List<IGameEventListener>();
                  

    public static void Register(IGameEventListener gameEventListener)
    {
        handlers.Add(gameEventListener);
    }

    public static void Unregister(IGameEventListener gameEventListener)
    {
        handlers.Remove(gameEventListener);
    }

    public static void Notify(GameEventType eventType, params object[] args)
    {
        //foreach (var handler in handlers)
        //{
        //    handler.OnGameEvent(eventType, args);
        //}
        foreach (IGameEventListener handler in new List<IGameEventListener>(handlers))
        {
            handler.OnGameEvent(eventType, args);
        }
    }
}
