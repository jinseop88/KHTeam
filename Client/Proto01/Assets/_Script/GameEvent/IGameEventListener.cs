using UnityEngine;
using System.Collections;

public interface IGameEventListener
{
    void OnGameEvent(GameEventType gameEventType);
}