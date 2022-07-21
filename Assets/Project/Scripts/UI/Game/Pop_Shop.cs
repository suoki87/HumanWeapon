using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;

namespace UI
{
    public class Pop_Shop : UIObject
    {
        public UISlotBuyStat[] stats;

        public override void OnOpen( object param = null )
        {
            base.OnOpen( param );

            foreach( var uiSlotBuyStat in stats )
            {
                uiSlotBuyStat.OnEnter();
            }
        }

        public override void OnClose()
        {
            base.OnClose();
        }

    }
}