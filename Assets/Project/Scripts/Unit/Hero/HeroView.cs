using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class HeroView : CharacterView
    {
        private Hero _hero;
        public override void OnEnter( Unit unit, UnitModel model )
        {
            base.OnEnter( unit, model );
            _hero = unit as Hero;
        }

        public void OnTransition( Hero.State state )
        {
            switch( state )
            {
                case Hero.State.Idle:
                    PlayAnimation( "Idle" );
                    break;
                case Hero.State.Run:
                    PlayAnimation( "Run" );
                    break;
                case Hero.State.Back:
                    PlayAnimation( "Back" );
                    break;
                case Hero.State.KnockBack:
                    PlayAnimation( "KnockBack" );
                    break;
                case Hero.State.Die:
                    PlayAnimation( "Die" );
                    break;
                default: throw new ArgumentOutOfRangeException( nameof(state), state, null );
            }
        }

        public void OnHit()
        {


        }

        public void OnDieComplete()
        {
            _hero.OnExit();
            Destroy( _hero );
            StageMan.In.OnHeroDie();
        }
    }
}