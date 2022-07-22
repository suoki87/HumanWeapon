using System;
using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using PlayCore;
using Tables;
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

            Broadcaster<string>.EnableListener( EventName.InputSkill, OnInputSkill );
        }

        public override void OnExit()
        {
            Broadcaster<string>.DisableListener( EventName.InputSkill, OnInputSkill );
            base.OnExit();
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
                    ChargeMp();
                    break;
                case State.Run:
                    RunProcess();
                    ChargeMp();
                    break;
                case State.Back:
                    BackProcess();
                    ChargeMp();
                    break;
                case State.KnockBack:
                    KnockbackProcess();
                    ChargeMp();
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

        void ChargeMp()
        {
            Model.ChargeMp();
            View.RefreshMp();
        }

        void IdleProcess()
        {
            //Nothing.
        }

        void RunProcess()
        {
            //런상태는 이제 가만히 있는상태이다.
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

        public float GetStat( STAT stat )
        {
            return Model.stat[stat];
        }

        public override bool IsAlive()
        {
            return Model.IsDie() == false;
        }

        public void OnHit( Unit attacker, float damage, HitType hitType )
        {
            if( Model.IsDie() ) {
                return;
            }

            if( Model.OnHit( damage, out float realDmg ) ) {
                //주금
                //..
                Transition( State.Die, true );
            } else {
                //Transition( State.KnockBack, true );
            }

            View.OnHit();
            HUDDamage.Spawn( position + new Vector3( -1f, 1f, 0f  ), realDmg.ToString("0.0"), Color.red );
        }

        public void OnLvUp()
        {
            Model.stat.SetDirty();
        }

        void OnInputSkill( string key )
        {
            var tblMagic = Table.Magic.Get( key );
            if( Model.stat[STAT.Mp] < tblMagic.mp ) {
                return;
            }

            var target = UnitMan.In.GetNearestMonster();
            if( target == null )
                return;

            Vector3 targetPos = target.position;
            Vector3 startPos = default;

            if( key == GDEItemKeys.Magic_Magic_1 ) {
                startPos = targetPos + Vector3.up * 5f;
            }
            else if( key == GDEItemKeys.Magic_Magic_2 ) {
                startPos = targetPos + ( Vector3.left * 10f );
            }

            var prefab = ResourceMan.In.GetPrefab( tblMagic.prefab );
            var magic = prefab.MakeInstance<Actor.Magic>();

            var magicModel = new MagicModel( magic, key );
            magic.OnEnter( magicModel );
            magic.Shot( target, startPos, targetPos );

            Model.stat[STAT.Mp] -= tblMagic.mp;
            Broadcaster.SendEvent( EventName.OnRefreshMpBar, TypeOfMessage.dontRequireReceiver );
        }
    }
}