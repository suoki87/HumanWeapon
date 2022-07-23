using System.Collections;
using System.Collections.Generic;
using Actor;
using Data;
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
            { STAT.Mp, 0f },
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
        var tblData = Table.Hero.Get( model.key );

        int atkLv = DataMan.In.statLv.GetLv( STAT.Atk );
        int defLv = DataMan.In.statLv.GetLv( STAT.Def );
        int movLv = DataMan.In.statLv.GetLv( STAT.MovSpd );
        int hpLv = DataMan.In.statLv.GetLv( STAT.MaxHp );
        int mpLv = DataMan.In.statLv.GetLv( STAT.MaxMp );

        _stats[STAT.Atk] = tblData.atk + atkLv;
        _stats[STAT.Def] = tblData.def + ( defLv * 0.01f );
        _stats[STAT.MaxHp] = tblData.hp + ( hpLv * 10 );
        _stats[STAT.MaxMp] = tblData.mp + ( mpLv * 10 );
        _stats[STAT.MovSpd] = tblData.mov + ( movLv * 0.05f );
        _stats[STAT.Crit] = tblData.crit;
        _stats[STAT.CritDmg] = tblData.critDmg;
        _stats[STAT.Tough] = tblData.toughness;
    }

    public override void ReFill()
    {
        _stats[STAT.Hp] = _stats[STAT.MaxHp];
        _stats[STAT.Mp] = _stats[STAT.MaxMp];
    }
}