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

        public HeroModel( Unit unit, string key ) : base( unit, key )
        {
            stat = new StatHero( this );
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
                default: throw new ArgumentOutOfRangeException( nameof(state), state, null );
            }

            this.state = state;
        }

        public bool IsDie()
        {
            return stat[STAT.Hp] <= 0;
        }

        public bool OnHit( float damage )
        {
            if( IsDie() ) {
                return true;
            }

            var def = stat[STAT.Def];
            var realDmg = Logic_Battle.CalcHitDamage( damage, def );
            stat[STAT.Hp] -= realDmg;
            return IsDie();
        }
    }
}