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

        public bool IsDie()
        {
            return stat[STAT.Hp] < 1;
        }

        /// <summary>
        /// return IsDie
        /// </summary>
        public bool OnHit( float damage, out float realDmg )
        {
            if( IsDie() ) {
                realDmg = damage;
                return true;
            }

            var def = stat[STAT.Def];
            realDmg = Logic_Battle.CalcHitDamage( damage, def );
            stat[STAT.Hp] -= realDmg;

            Log.Battle.I($"Monster OnHit Dmg:{damage} Def:{def} RealDmg:{realDmg}  HP:{stat[STAT.Hp]} / {stat[STAT.MaxHp]}"  );
            return IsDie();
        }
    }
}