using System.Collections;
using System.Collections.Generic;
using Actor;
using Tables;
using UnityEngine;

public class StatHero : Stat
{
    public StatHero( IStatDataHandler dataHandler ) : base( dataHandler )
    {
        _stats[STAT.Hp] = _stats[STAT.MaxHp];
    }

    protected override void NewStats()
    {
        _stats = new DicStat( 16 )
        {
            { STAT.Atk, 0f },
            { STAT.Def, 0f },
            { STAT.Hp, 0f },
            { STAT.MaxHp, 0f },
            { STAT.MovSpd, 0f },
            { STAT.Crit, 0f},
            { STAT.CritDmg, 0f},
            { STAT.Tough, 0f},
        };
    }

    protected override void CalcStats()
    {
        var model = _dataHandler as HeroModel;
        var tblData = Table.hero.Get( model.key );

        _stats[STAT.Atk] = tblData.atk;
        _stats[STAT.Def] = tblData.def;
        _stats[STAT.MaxHp] = tblData.hp;
        _stats[STAT.Hp] = _stats[STAT.MaxHp];
        _stats[STAT.MovSpd] = tblData.mov;
        _stats[STAT.Crit] = tblData.crit;
        _stats[STAT.CritDmg] = tblData.critDmg;
        _stats[STAT.Tough] = tblData.toughness;
    }
}