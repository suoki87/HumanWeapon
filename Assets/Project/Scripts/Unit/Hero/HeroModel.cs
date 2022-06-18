using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class HeroModel : CharacterModel, IStatDataHandler
    {
        public Stat stat { get; set; }
        public HeroModel( Unit unit, string key ) : base( unit, key )
        {
            stat = new StatHero( this );
        }


    }
}