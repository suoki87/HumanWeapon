using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class HeroModel : CharacterModel, IStatDataHandler
    {
        private Hero _hero;
        public Hero.State state = Hero.State.Idle;

        public Stat stat { get; set; }

        public float knockBackTick = 0f;
        public float knockBackTime = 0.8f;
        public Vector3 knockBackTargetPos = Vector3.zero;

        private float mpChargeSpeed = 5f;

        public HeroModel( Unit unit, string key ) : base( unit, key )
        {
            stat = new StatHero( this );
            stat.ReFill();
            _hero = unit as Hero;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            stat.SetDirty();
        }

        public void OnTransition( Hero.State state )
        {
            switch( state )
            {
                case Hero.State.Idle: break;
                case Hero.State.Run: break;
                case Hero.State.Back: break;
                case Hero.State.KnockBack:
                    knockBackTargetPos = _hero.position + ( Vector3.left * 2f );
                    knockBackTick = 0f;
                    break;
                case Hero.State.Die: break;
                default: throw new ArgumentOutOfRangeException( nameof(state), state, null );
            }

            this.state = state;
        }

        public bool IsDie()
        {
            return stat[STAT.Hp] < 1;
        }

        public bool OnHit( float damage, out float realDmg )
        {
            if( IsDie() ) {
                realDmg = damage;
                return true;
            }

            var def = stat[STAT.Def];
            realDmg = Logic_Battle.CalcHitDamage( damage, def );
            stat[STAT.Hp] -= realDmg;

            return IsDie();
        }

        public void HpRecover()
        {
            stat[STAT.Hp] += (stat[STAT.MaxHp] / 10) * Time.deltaTime;
            Broadcaster.SendEvent( EventName.UIRefresh, TypeOfMessage.dontRequireReceiver );
        }

        public void ChargeMp()
        {
            var maxMp = stat[STAT.MaxMp];
            stat[STAT.Mp] += mpChargeSpeed * Time.deltaTime;
            stat[STAT.Mp] = Mathf.Min( stat[STAT.Mp], maxMp );
        }
    }
}