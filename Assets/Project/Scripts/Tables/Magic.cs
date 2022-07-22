using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using UnityEngine;

namespace Tables
{
    public class Magic : TableDataBase<GDEMagicData>
    {
        public enum MoveType
        {
            Linear,
            //Curve,
        }

        public MoveType GetMoveType( string key )
        {
            return Get( key ).MovType.ToEnum<MoveType>();
        }

    }
}