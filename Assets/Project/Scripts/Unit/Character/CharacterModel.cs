using System;
using GameDataEditor;

namespace Actor
{
    public class CharacterModel : UnitModel
    {
        protected Character character;

        public CharacterModel( Unit unit, string key ) : base( unit, key )
        {
            character = unit as Character;
        }

        public override void OnEnter()
        {
            base.OnEnter();
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}