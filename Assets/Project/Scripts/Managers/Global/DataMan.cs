using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using Tables;
using UnityEngine;

namespace Data
{
    public class DataMan : SingletonMono<DataMan>
    {
        public int stageNo = 1;

        public void Init()
        {
            stageNo = 1;
        }

    }


}