using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Actor
{
    public class CharacterView : UnitView
    {
        public SpriteRenderer render;
        protected Character character;
        protected CharacterModel charModel;

        public override void OnEnter( Unit unit, UnitModel model )
        {
            base.OnEnter( unit, model );
            character = unit as Character;
            charModel = unitModel as CharacterModel;
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}