﻿using UnityEngine;

namespace Actor
{
    public class Character : Unit
    {
        protected CharacterModel charModel;
        protected CharacterView charView;

        public override void OnEnter( UnitModel model )
        {
            base.OnEnter( model );
            charModel = unitModel as CharacterModel;
            charView = unitView as CharacterView;
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public override void Process()
        {
            base.Process();
        }
    }
}