using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class HeroModel : CharacterModel, IStatDataHandler
    {

        public Hero.State state = Hero.State.Idle;

        public Stat stat { get; set; }

        public float knockBackTick = 0f;
        public float knockBackTime = 0.8f;

        public HeroModel( Unit unit, string key ) : base( unit, key )
        {
            stat = new StatHero( this );
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
                    knockBackTick = 0f;
                    break;
                default: throw new ArgumentOutOfRangeException( nameof(state), state, null );
            }

            this.state = state;
        }
    }
}