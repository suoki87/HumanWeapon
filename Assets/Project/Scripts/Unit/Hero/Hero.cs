using System;
using System.Collections;
using System.Collections.Generic;
using PlayCore;
using UI;
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
            Die,
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
                case State.Die:
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
            var movSpd = Model.stat[STAT.MovSpd];
            position += Vector3.left * movSpd * Time.deltaTime * 0.5f;
            Model.HpRecover();
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

            if( Model.OnHit( damage, out float realDmg ) ) {
                //주금
                //..

                Transition( State.Die, true );

            } else {
                Transition( State.KnockBack, true );
                View.OnHit();
            }

            HUDDamage.Spawn( position + new Vector3( -1f, 1f, 0f  ), realDmg.ToString("0.0"), Color.red );

            Broadcaster.SendEvent( EventName.OnHit, TypeOfMessage.dontRequireReceiver );
        }

        public void OnLvUp()
        {
            Model.stat.SetDirty();
        }

        public void OnEnterInput()
        {
            if( Model.state == State.Run ) {
                Transition( State.Back, false );
            }
        }

        public void OnExitInput()
        {
            if( Model.state == State.Back ) {
                Transition( State.Run, false );
            }
        }
    }
}