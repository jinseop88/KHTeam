using UnityEngine;
using System.Collections;

public class UIButtonBase : UIBase 
{
    public EventDelegate onClick;

    public virtual void OnClick()
    {
        if (onClick.isValid)
            onClick.Execute();
    }
}
