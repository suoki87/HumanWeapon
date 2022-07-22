using System;
using System.Collections;
using System.Collections.Generic;
using Actor;
using Data;
using DG.Tweening;
using GameDataEditor;
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
        public Slider mpBar;
        public TMP_Text txtCurHp;
        public TMP_Text txtCurMp;
        public TMP_Text txtGold;



        public override void OnOpen( object param = null )
        {
            base.OnOpen( param );
            Broadcaster.EnableListener( EventName.OnStatLvUp, OnRefreshStat );
            Broadcaster.EnableListener( EventName.OnMonsterDie, OnMonsterDie );
            Broadcaster.EnableListener( EventName.OnHit, OnRefreshHpBar );
            Broadcaster.EnableListener( EventName.OnRefreshMpBar, OnRefreshMpBar );
            Broadcaster.EnableListener( EventName.UIRefresh, RefreshAll );
            RefreshAll();
        }

        public override void OnClose()
        {
            Broadcaster.DisableListener( EventName.OnStatLvUp, OnRefreshStat );
            Broadcaster.DisableListener( EventName.OnMonsterDie, OnMonsterDie );
            Broadcaster.DisableListener( EventName.OnHit, OnRefreshHpBar );
            Broadcaster.DisableListener( EventName.OnRefreshMpBar, OnRefreshMpBar );
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

        void OnRefreshMpBar()
        {
            var hero = UnitMan.In.hero;
            var curMp = hero.GetStat( STAT.Mp );
            var maxMp = hero.GetStat( STAT.MaxMp );

            txtCurMp.text = string.Format( "{0}/{1}", (int)curMp, (int)maxMp );
            mpBar.value = curMp / maxMp;
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

        public void OnBtnShop()
        {
            UIMan.In.Open( UIKind.Pop_Shop );
        }

        public void OnBtnPotion(int index)
        {
            if( index == 0 )
            {
                //hp
            }
            else if( index == 1 )
            {
                //mp.
            }
        }

        public void OnBtnSkill( int index )
        {
            string key = string.Empty;
            if( index == 0 ) {
                key = GDEItemKeys.Magic_Magic_1;
            }
            else if( index == 1 ) {
                key = GDEItemKeys.Magic_Magic_2;

            }
            //BroadCast Hero And Hero Make Magic, Before CHeck Mana. status
            Broadcaster<string>.SendEvent( EventName.InputSkill, key, TypeOfMessage.dontRequireReceiver );
        }
    }
}