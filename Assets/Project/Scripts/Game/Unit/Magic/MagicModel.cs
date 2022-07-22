using System;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using Tables;
using UnityEngine;

namespace Actor
{
    public class MagicModel : CharacterModel
    {
        public float shotTick = 0f;

        public Vector3 startPos;
        public Vector3 targetPos;

        public GDEMagicData tblData;
        public MagicModel( Unit unit, string key ) : base( unit, key )
        {
            tblData = Table.Magic.Get( key );
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public void Shot( Vector3 startPos, Vector3 targetPos )
        {
            this.startPos = startPos;
            this.targetPos = targetPos;
            shotTick = 0f;
        }
    }
}