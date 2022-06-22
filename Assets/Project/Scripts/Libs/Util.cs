using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    //--------------------------------------------------------------------------------
    public static void TransformIdentity( Transform parent, Transform trans )
    {
        TransformIdentity( parent, trans, Vector3.zero, Quaternion.identity, Vector3.one );
    }

    //--------------------------------------------------------------------------------
    public static void TransformIdentity( Transform parent, Transform trans, Vector3 position )
    {
        TransformIdentity( parent, trans, position, Quaternion.identity, Vector3.one );
    }

    //--------------------------------------------------------------------------------
    public static void TransformIdentity( Transform parent, Transform trans, Vector3 position, Quaternion rotate )
    {
        TransformIdentity( parent, trans, position, rotate, Vector3.one );
    }

    //--------------------------------------------------------------------------------
    public static void TransformIdentity( Transform parent, Transform trans, Vector3 position, Quaternion rotate,
        Vector3 scale )
    {
        bool worldPositionStays = !( trans is RectTransform );
        trans.SetParent( parent, worldPositionStays );
        trans.position = position;
        trans.rotation = rotate;
        trans.localScale = scale;
    }

    //--------------------------------------------------------------------------------
    public static void TransformIdentityLocal( Transform parent, Transform trans )
    {
        TransformIdentityLocal( parent, trans, Vector3.zero, Quaternion.identity, Vector3.one );
    }

    //--------------------------------------------------------------------------------
    public static void TransformIdentityLocal( Transform parent, Transform trans, Vector3 position )
    {
        TransformIdentityLocal( parent, trans, position, Quaternion.identity, Vector3.one );
    }

    //--------------------------------------------------------------------------------
    public static void TransformIdentityLocal( Transform parent, Transform trans, Vector3 position, Quaternion rotate )
    {
        TransformIdentityLocal( parent, trans, position, rotate, Vector3.one );
    }

    //--------------------------------------------------------------------------------
    public static void TransformIdentityLocal( Transform parent, Transform trans, Vector3 position, Quaternion rotate,
        Vector3 scale )
    {
        bool worldPositionStays = !( trans is RectTransform );
        trans.SetParent( parent, worldPositionStays );
        trans.localPosition = position;
        trans.localRotation = rotate;
        trans.localScale = scale;
    }
}