using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Logic_Battle
{
    public static float CalcDamage( float atk, float crit, float critDmg )
    {
        var damage = atk;
        if( Rands.PercentF( crit ) ) {
            damage *= (critDmg * 0.01f);
        }
        return damage;
    }

    public static float CalcHitDamage( float damage, float def )
    {
        //방어율만큼 깍는다.
        var realDmg = damage / ( 1 + ( def * 0.01f ) );
        //최소 1의 데미지
        if( realDmg < 1 ) {
            realDmg = 1;
        }
        return realDmg;
    }
}