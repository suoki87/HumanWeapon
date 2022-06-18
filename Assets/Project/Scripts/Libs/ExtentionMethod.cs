using System.Collections;
using System.Collections.Generic;
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
}