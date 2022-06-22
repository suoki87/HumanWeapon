using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class HeroView : CharacterView
    {
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
                    PlayAnimation( "Idle" );
                    break;
                case Hero.State.KnockBack:
                    PlayAnimation( "Idle" );
                    break;
                default: throw new ArgumentOutOfRangeException( nameof(state), state, null );
            }
        }
    }
}