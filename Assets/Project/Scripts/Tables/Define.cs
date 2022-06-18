using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;

namespace Tables
{
    public class Define : TableDataBase<GDEDefineData>
    {
        public float GetValue(string key)
        {
            var data = Get( key );
            return data.value;
        }
    }
}