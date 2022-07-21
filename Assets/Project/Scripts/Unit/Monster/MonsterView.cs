using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace Actor
{
    public class MonsterView : CharacterView
    {
        private MonsterModel Model;
        HPBar hpBar;
        public Transform hpPivot;

        public override void OnEnter( Unit unit, UnitModel model )
        {
            base.OnEnter( unit, model );
            Model = model as MonsterModel;

            hpBar = ObjectMan.In.SpawnHpBar();
            hpBar.OnEnter( hpPivot );
            hpBar.OnRefresh( Model.stat[STAT.Hp], Model.stat[STAT.MaxHp] );
        }

        public override void OnExit()
        {
            hpBar.OnExit();
            Destroy( hpBar );
            hpBar = null;
            base.OnExit();
        }

        public void OnHit(float cur, float max)
        {
            if( hpBar != null ) {
                hpBar.OnRefresh( cur, max );
            }
        }

        public void OnTransition( Monster.State state )
        {


        }
    }
}