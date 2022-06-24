using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class HeroBody : MonoBehaviour, ICollidable
    {
        public Hero hero;

        public void OnEnterTrigger( Unit target )
        {
            if( target.TryGetComponent( out IHittable hittable ) )
            {
                var dmg = Logic_Battle.CalcDamage(
                    hero.GetStat( STAT.Atk ),
                    hero.GetStat( STAT.Crit ),
                    hero.GetStat( STAT.CritDmg ) );
                hittable.OnHit( hero, dmg );
            }
        }

        public void OnExitTrigger( Unit target )
        {

        }
    }
}