using System.Collections;
using System.Collections.Generic;
using GameDataEditor;
using Tables;
using UnityEngine;

namespace Data
{
    public class DataMan : SingletonMono<DataMan>
    {
        public int stageNo = 1;
        public int gold = 0;

        public StatLv statLv = new StatLv();

        public void Init()
        {
            stageNo = 1;
            gold = 0;
            statLv.Init();
        }

        public void LvUp( STAT stat )
        {
            statLv.AddVal( stat, 1 );
        }
    }

    public class StatLv
    {
        public Dictionary<STAT, int> stats = new Dictionary<STAT, int>();
        public void Init()
        {
            stats.Add( STAT.Atk, 0 );
            stats.Add( STAT.Def, 0 );
            stats.Add( STAT.MovSpd, 0 );
            stats.Add( STAT.Hp, 0 );
        }

        public void AddVal(STAT stat, int adder)
        {
            stats[stat] += adder;
        }

        public int GetLv( STAT stat )
        {
            return stats[stat];
        }
    }
}