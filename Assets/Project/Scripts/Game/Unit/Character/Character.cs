using PlayCore;
using UnityEngine;

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

        public virtual bool IsAlive() {
            return true;
        }

        public virtual Vector3 Move(PlayCore.EaseType ease, Vector3 startPos, Vector3 destPos, float t, float time)
        {
            return Easing.Ease(ease, startPos, destPos, t / time);
        }
    }
}