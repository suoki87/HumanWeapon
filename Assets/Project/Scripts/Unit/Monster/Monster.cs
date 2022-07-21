using System;
using System.Collections;
using System.Collections.Generic;
using PlayCore;
using UI;
using UnityEngine;

namespace Actor
{
    public class Monster : Character, IHittable
    {
        protected MonsterModel Model;
        protected MonsterView View;

        public enum State
        {
            Idle,
            Run,
            KnockBack,
            Die,
        }

        public override void OnEnter( UnitModel model )
        {
            base.OnEnter( model );
            Model = unitModel as MonsterModel;
            View = unitView as MonsterView;
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public void OnHit( Unit attacker, float damage )
        {
            if( Model.OnHit( damage, out float realDmg ) ) {
                //주금.
                OnExit();
                Destroy( gameObject );
                StageMan.In.OnMonsterDie();
            } else {
                View.OnHit( Model.stat[STAT.Hp], Model.stat[STAT.MaxHp] );
                //몬스터가 죽지 않으면 플레이어를 피격.
                if( attacker.TryGetComponent( out IHittable hitter ) ) {
                    hitter.OnHit( this, Model.stat[STAT.Atk] );
                }
                Transition( Monster.State.KnockBack, true );
            }

            HUDDamage.Spawn( position + new Vector3( 1f, 1f, 0f  ), realDmg.ToString("0.0"), Color.white );
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
                case State.KnockBack:
                    KnockbackProcess();
                    break;
                case State.Die:
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }


        void IdleProcess()
        {

        }

        void RunProcess()
        {
        }

        void KnockbackProcess()
        {
            position = Move( EaseType.OutCubic, position, Model.knockBackTargetPos, Model.knockBackTick, Model.knockBackTime );
            Model.knockBackTick += Time.deltaTime;
            if( Model.knockBackTick >= Model.knockBackTime * 0.9f )
            {
                Transition( State.Idle, true );
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
    }
}