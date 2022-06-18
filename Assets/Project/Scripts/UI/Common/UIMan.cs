using System;
using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;


//프리팹이름과 동일하게.
public enum UIKind
{
    Pan_Title,
    Pan_Game,
    //..
}

public class UIMan : SingletonMono<UIMan>
{
    //현재 열려있는 UI.

    public Dictionary<UIKind, UIObject> uis = new Dictionary<UIKind, UIObject>();

    public void Open(UIKind kind, object param = null )
    {

    }

    public void Close( UIKind kind )
    {

    }
}