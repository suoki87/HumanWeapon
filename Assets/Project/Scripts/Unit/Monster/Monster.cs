using System.Collections;
using System.Collections.Generic;
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

        public void OnHit( Unit attacker, float damage )
        {
            if( Model.OnHit( damage ) ) {
                //주금.
                OnExit();
                Destroy( gameObject );
                StageMan.In.OnMonsterDie();
            } else {
                View.OnHit();

                //몬스터가 죽지 않으면 플레이어를 피격.
                if( attacker.TryGetComponent( out IHittable hitter ) ) {
                    hitter.OnHit( this, Model.stat[STAT.Atk] );
                }
            }
        }
    }
}