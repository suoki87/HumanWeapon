using System.Collections;
using System.Collections.Generic;
using Actor;
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

        _stats[STAT.Atk] = ( Balance.MONSTER_ATK_PER_STAGE * stageNo ) + groupNo;
        _stats[STAT.Def] = ( Balance.MONSTER_DEF_PER_STAGE * stageNo );
        _stats[STAT.MaxHp] = ( Balance.MONSTER_HP_PER_STAGE * stageNo ) + groupNo;;
        _stats[STAT.Hp] = _stats[STAT.MaxHp];
        _stats[STAT.MovSpd] = 0f;
        _stats[STAT.Crit] = 0f;
        _stats[STAT.CritDmg] = 0f;
        _stats[STAT.Tough] = 10f;
    }
}