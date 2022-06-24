using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Actor
{
    public class Monster : Character, IHittable
    {
        protected MonsterModel Model;
        protected MonsterView View;

        public override void OnEnter( UnitModel model )
        {
            base.OnEnter( model );
            Model = unitModel as MonsterModel;
            View = unitView as MonsterView;
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        public void OnHit( Unit attacker, float damage )
        {
            if( Model.OnHit( damage, out float realDmg ) ) {
                //주금.
                OnExit();
                Destroy( gameObject );
                StageMan.In.OnMonsterDie();
            } else {
                View.OnHit( Model.stat[STAT.Hp], Model.stat[STAT.MaxHp] );
                //몬스터가 죽지 않으면 플레이어를 피격.
                if( attacker.TryGetComponent( out IHittable hitter ) ) {
                    hitter.OnHit( this, Model.stat[STAT.Atk] );
                }
            }

            HUDDamage.Spawn( position + new Vector3( 1f, 1f, 0f  ), realDmg.ToString("0.0"), Color.white );
        }
    }
}