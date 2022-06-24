using System.Collections;
using System.Collections.Generic;
using Actor;
using Tables;
using UnityEngine;

public class StatMonster : Stat
{
    public StatMonster( IStatDataHandler dataHandler ) : base( dataHandler )
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
            { STAT.Crit, 0f },
            { STAT.CritDmg, 0f },
            { STAT.Tough, 0f },
        };
    }

    protected override void CalcStats()
    {
        var model = _dataHandler as MonsterModel;
        var stageNo = model.stageNo;
        var groupNo = model.groupNo;

        var tbl = Table.monster.Get( model.key );

        var atk = tbl.atk * Mathf.Pow( 1.04f, stageNo - 1);
        var def = tbl.def + ( stageNo / 10 );
        var hp = tbl.hp * Mathf.Pow( 1.1f, stageNo - 1);

        _stats[STAT.Atk] = atk;
        _stats[STAT.Def] = def;
        _stats[STAT.MaxHp] = hp;
        _stats[STAT.MovSpd] = tbl.mov;
        _stats[STAT.Crit] = tbl.crit;
        _stats[STAT.CritDmg] = tbl.critDmg;
        _stats[STAT.Tough] = tbl.toughness;
        _stats[STAT.Hp] = _stats[STAT.MaxHp];
    }

    public override void ReFill()
    {
        _stats[STAT.Hp] = _stats[STAT.MaxHp];
    }
}