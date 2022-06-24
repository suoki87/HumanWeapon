using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UISlotBuyStat : MonoBehaviour
    {
        public TMP_Text textStat;
        public TMP_Text textPrice;

        public STAT statKind = STAT.None;

        public void OnEnter()
        {
            Refresh();
        }

        public void Refresh()
        {
            int lv = DataMan.In.statLv.GetLv( statKind );
            int gold = DataMan.In.gold;
            var price = Logic_Game.GetStatPrice( lv );

            textStat.text = statKind.ToString();
            textPrice.text = price.ToString();
        }

        public void OnBtnLvUp()
        {
            int lv = DataMan.In.statLv.GetLv( statKind );
            int gold = DataMan.In.gold;
            var price = Logic_Game.GetStatPrice( lv );
            if( gold < price ) {
                return;
            }

            DataMan.In.gold -= price;
            DataMan.In.LvUp( statKind );

            Refresh();

            Broadcaster.SendEvent( EventName.OnStatLvUp, TypeOfMessage.dontRequireReceiver );
            //Broadcaster.SendEvent( EventName.OnRefreshHpBar );
        }
    }
}