using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class MonsterModel : CharacterModel, IStatDataHandler
    {
        public Stat stat { get; set; }
        public MonsterModel( Unit unit, string key ) : base( unit, key )
        {
            stat = new StatMonster( this );
        }
    }
}