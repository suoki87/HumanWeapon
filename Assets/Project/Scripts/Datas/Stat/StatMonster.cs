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
        // _stats[STAT.BaseSpd] = model.tblHero.speed;
        // _stats[STAT.BaseGrit] = model.tblCharacter.grit;
        // _stats[STAT.BasePower] = model.tblCharacter.power;
        // _stats[STAT.BaseHealth] = model.tblCharacter.hp;
        // _stats[STAT.BaseLuck] = model.tblCharacter.luck;
        //
        // _stats[STAT.MaxHp] = StatCalc.GetCharacterMaxHp( model.tblCharacter.hp );
        // _stats[STAT.Stamina] = StatCalc.GetCharacterMaxStamina( model.tblCharacter.grit );
    }
}