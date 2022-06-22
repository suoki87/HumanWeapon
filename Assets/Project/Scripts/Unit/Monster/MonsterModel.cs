using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class MonsterModel : CharacterModel, IStatDataHandler
    {
        public int stageNo;
        public int groupNo;

        public Stat stat { get; set; }
        public MonsterModel( Unit unit, string key ) : base( unit, key )
        {
            stat = new StatMonster( this );
            stat.SetDirty();
        }

        public void SetData(int stageNo, int groupNo)
        {
            this.stageNo = stageNo;
            this.groupNo = groupNo;
        }
    }
}