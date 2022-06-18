
using UnityEngine;

public static class GameObjectEx
{
    public static T MakeInstance<T>( this GameObject originalPrefab ) where T : Component
    {
        return originalPrefab.MakeInstance().GetComponent<T>();
    }

    public static T MakeInstance<T>( this GameObject originalPrefab, Transform root ) where T : Component
    {
        return originalPrefab.MakeInstance( root ).GetComponent<T>();
    }

    public static GameObject MakeInstance( this GameObject originalPrefab, Transform root=null )
    {
        if( root == null )
            root = originalPrefab.transform.parent;
        GameObject go = GameObject.Instantiate( originalPrefab, root, false ) as GameObject;
        return go;
    }

    public static GameObject MakeInstanceWithActivate( this GameObject originalPrefab, Transform root = null )
    {
        var go = originalPrefab.MakeInstance( root );
        go.SetActive( true );
        return go;
    }

    public static T MakeInstanceWithActivate<T>( this GameObject originalPrefab, Transform root = null )
    {
        var go = originalPrefab.MakeInstance( root );
        go.SetActive( true );
        return go.GetComponent<T>();
    }
}