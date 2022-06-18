using UnityEngine;

namespace Actor
{
    public class Character : Unit
    {
        protected CharacterModel charModel;
        protected CharacterView charView;

        public override void OnEnter( UnitModel model, UnitView view )
        {
            base.OnEnter( model, view );
            charModel = model as CharacterModel;
            charView = view as CharacterView;
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