using UnityEngine;
using System.Collections;

public class UI_Ingame : UIBase, IGameEventListener
{
    public GameObject magicNotice;

    public override void Initialize()
    {
        base.Initialize();

        GameEventManager.Register(this);
    }

    public void TouchScreen()
    {
        GameEventManager.Notify(GameEventType.ClickScreen);

        if (magicNotice.activeSelf)
            magicNotice.SetActive(false);
    }

    public void OnGameEvent(GameEventType gameEventType, params object[] args)
    {
        switch(gameEventType)
        {
            case  GameEventType.ReadyMagic:
                magicNotice.SetActive(true);
                break;

        }
    }
    
}
