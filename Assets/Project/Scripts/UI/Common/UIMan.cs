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
    Pop_Shop,
    //..
}

public class UIMan : SingletonMono<UIMan>
{
    //현재 열려있는 UI.
    public List<UIObject> uis = new List<UIObject>();

    private UIHolder uiHolder = null;

    public void OnSceneChanged()
    {
        uiHolder = FindObjectOfType<UIHolder>();
    }

    public void Open(UIKind kind, object param = null )
    {
        var prefab = ResourceMan.In.GetPrefab( kind.ToString() );
        var ui = prefab.MakeInstance<UIObject>( uiHolder.popupHolder );
        ui.OnOpen( param );
        uis.Add( ui );
    }

    public void Close( UIObject ui )
    {
        ui.OnClose();
        uis.Remove( ui );
        Destroy( ui.gameObject );
    }

    public void CloseAllPopUp()
    {
        foreach( var ui in uis )
        {
            ui.OnClose();
            Destroy( ui.gameObject );
        }
        uis.Clear();
    }
}