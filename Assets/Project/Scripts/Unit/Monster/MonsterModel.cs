using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class MonsterModel : CharacterModel, IStatDataHandler
    {
        public int stageNo;
        public int groupNo;

        public Monster.State state = Monster.State.Idle;

        public float knockBackTick = 0f;
        public float knockBackTime = 2f;
        public Vector3 knockBackTargetPos = Vector3.zero;

        private Monster _monster;
        public Stat stat { get; set; }
        public MonsterModel( Unit unit, string key ) : base( unit, key )
        {
            stat = new StatMonster( this );
            stat.SetDirty();
            _monster = unit as Monster;
        }

        public void SetData(int stageNo, int groupNo)
        {
            this.stageNo = stageNo;
            this.groupNo = groupNo;
        }

        public bool IsDie()
        {
            return stat[STAT.Hp] <= 0f;
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

        public void OnTransition( Monster.State state )
        {
            switch( state )
            {
                case Monster.State.Idle: break;
                case Monster.State.Run: break;
                case Monster.State.KnockBack:
                    knockBackTargetPos = _monster.position + ( Vector3.right * Rands.Range( 1f, 2f ) );
                    knockBackTick = 0f;
                    break;
                case Monster.State.Die:
                    break;
                default: throw new ArgumentOutOfRangeException( nameof(state), state, null );
            }
            this.state = state;
        }
    }
}