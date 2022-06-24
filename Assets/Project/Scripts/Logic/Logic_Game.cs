using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Logic_Game
{
    public static int GetStatPrice( int curLv )
    {
        var basePrice = Balance.STAT_PRICE_DEFAULT;
        var rate = Balance.STAT_UPPER_RATE;
        return Mathf.CeilToInt(  GetMul( basePrice, rate, curLv) );
    }

    public static int GetDropGold( int stageNo )
    {
        var baseGold = Balance.DROP_GOLD_DEFAULT;
        var rate = Balance.DROP_GOLD_RATE;
        return Mathf.FloorToInt( GetMul(  baseGold, rate, stageNo - 1) );
    }

    static float GetMul( float defaultVal, float rate,  int no )
    {
        return defaultVal * Mathf.Pow( rate, no );
    }



}