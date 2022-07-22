using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class MagicView : CharacterView
    {
        public GameObject prefabBurst;

        public override void OnEnter( Unit unit, UnitModel model )
        {
            base.OnEnter( unit, model );
        }

        public void OnBurst()
        {
            var obj = prefabBurst.MakeInstance( );
            obj.transform.position = position;
        }
    }
}