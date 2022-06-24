using System;
using System.Collections;
using System.Collections.Generic;
using PlayCore;
using UnityEngine;

namespace Actor
{
    public class Hero : Character, IHittable
    {
        protected HeroModel Model;
        protected HeroView View;

        public enum State
        {
            Idle,
            Run,
            Back,
            KnockBack,
        }

        public override void OnEnter( UnitModel model )
        {
            base.OnEnter( model );
            Model = unitModel as HeroModel;
            View = unitView as HeroView;


        }

        public void OnPlay()
        {
            Transition( State.Run, true );
        }

        public override void Process()
        {
            base.Process();
            switch( Model.state )
            {
                case State.Idle:
                    IdleProcess();
                    break;
                case State.Run:
                    RunProcess();
                    break;
                case State.Back:
                    BackProcess();
                    break;
                case State.KnockBack:
                    KnockbackProcess();
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }

        void Transition( State state, bool force )
        {
            if( state == Model.state && !force) {
                return;
            }
            Model.OnTransition( state );
            View.OnTransition( state );
        }

        void IdleProcess()
        {
            //Nothing.
        }

        void RunProcess()
        {
            var movSpd = Model.stat[STAT.MovSpd];
            position += Vector3.right * movSpd * Time.deltaTime;
        }

        void BackProcess()
        {
            var movspd = 5f;
            position += Vector3.left * movspd * Time.deltaTime;
        }

        void KnockbackProcess()
        {
            position = Move( EaseType.OutCubic, position, Model.knockBackTargetPos, Model.knockBackTick, Model.knockBackTime );
            Model.knockBackTick += Time.deltaTime;
            if( Model.knockBackTick >= Model.knockBackTime * 0.9f )
            {
                Transition( State.Run, true );
            }
        }

        public virtual Vector3 Move(PlayCore.EaseType ease, Vector3 startPos, Vector3 destPos, float t, float time)
        {
            return Easing.Ease(ease, startPos, destPos, t / time);
        }

        public float GetStat( STAT stat )
        {
            return Model.stat[stat];
        }

        public void OnHit( Unit attacker, float damage )
        {
            if( Model.IsDie() ) {
                return;
            }

            if( Model.OnHit( damage ) ) {
                //주금
                //..
                OnExit();
                Destroy( gameObject );
                StageMan.In.OnHeroDie();
            } else {
                Transition( State.KnockBack, true );
                View.OnHit();
            }

            Broadcaster.SendEvent( EventName.OnHit );
        }

        public void OnLvUp()
        {
            Model.stat.SetDirty();
        }
    }
}