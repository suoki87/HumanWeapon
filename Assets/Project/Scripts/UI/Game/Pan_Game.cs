using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using DG.Tweening;
using SceneMode;
using Tables;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class Pan_Game : UIObject
    {
        public TMP_Text txtAtk;
        public TMP_Text txtDef;
        public TMP_Text txtSpd;
        public TMP_Text txtHp;

        public TMP_Text txtStageNo;
        public TMP_Text txtMonsterCount;

        public Slider hpBar;
        public TMP_Text txtCurHp;
        public TMP_Text txtGold;

        public UISlotBuyStat[] stats;

        public override void OnOpen( object param = null )
        {
            base.OnOpen( param );
            Broadcaster.EnableListener( EventName.OnStatLvUp, OnRefreshStat );
            Broadcaster.EnableListener( EventName.OnMonsterDie, OnMonsterDie );
            Broadcaster.EnableListener( EventName.OnHit, OnRefreshHpBar );
            Broadcaster.EnableListener( EventName.UIRefresh, RefreshAll );
            RefreshAll();

            foreach( var uiSlotBuyStat in stats )
            {
                uiSlotBuyStat.OnEnter();
            }
        }

        public override void OnClose()
        {
            Broadcaster.DisableListener( EventName.OnStatLvUp, OnRefreshStat );
            Broadcaster.DisableListener( EventName.OnMonsterDie, OnMonsterDie );
            Broadcaster.DisableListener( EventName.OnHit, OnRefreshHpBar );
            Broadcaster.DisableListener( EventName.UIRefresh, RefreshAll );
            base.OnClose();
        }

        public void RefreshAll()
        {
            OnRefreshStageNo();
            OnMonsterDie();
            OnRefreshStat();
            OnRefreshHpBar();
            OnRefreshGold();
        }

        void OnRefreshStageNo()
        {
            txtStageNo.text = string.Format( "StageNo - {0}", DataMan.In.stageNo  );
        }

        void OnRefreshHpBar()
        {
            var hero = UnitMan.In.hero;
            var curHp = hero.GetStat( STAT.Hp );
            var maxHp = hero.GetStat( STAT.MaxHp );

            txtCurHp.text = string.Format( "{0}/{1}", (int)curHp, (int)maxHp );
            hpBar.value = curHp / maxHp;
        }

        void OnRefreshGold()
        {
            txtGold.text = DataMan.In.gold.ToString();
        }

        void OnMonsterDie()
        {
            OnRefreshGold();
            RefreshMonsterCount();
        }

        void RefreshMonsterCount()
        {
            txtMonsterCount.text = string.Format( "M - {0}", StageMan.In.monsterCount  );
        }

        void OnRefreshStat()
        {
            var hero = UnitMan.In.hero;
            txtAtk.text = string.Format( "ATK : {0:0.00}", hero.GetStat( STAT.Atk ) );
            txtDef.text = string.Format( "DEFK : {0:0.00}", hero.GetStat( STAT.Def ) );
            txtSpd.text = string.Format( "SPD : {0:0.00}", hero.GetStat( STAT.MovSpd ) );
            txtHp.text = string.Format( "MAXHP : {0:0.00}", hero.GetStat( STAT.MaxHp ) );
            OnRefreshGold();
        }

        public void OnEnterInput()
        {
            UnitMan.In.hero.OnEnterInput();
        }

        public void OnExitInput()
        {
            UnitMan.In.hero.OnExitInput();
        }
    }
}