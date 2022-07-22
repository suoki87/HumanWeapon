using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ExtentionMethod
{
    static public T GetSmartComponent<T>(this GameObject self) where T : Component
    {
        T t = default(T);
        t = self.GetComponent<T>();
        if (t == default(T)) {
            t = self.AddComponent<T>();
        }
        return t;
    }

    public static void ForReverse<T>( this List<T> source, Action<T> elem )
    {
        for( int i = source.Count() - 1; i >= 0; i-- )
        {
            Log.to.I($"For Reverse {i}" );
            elem.Invoke( source[i] );
        }
    }
}