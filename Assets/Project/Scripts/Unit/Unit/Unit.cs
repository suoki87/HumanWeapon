using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class Unit : MonoBase
    {
        protected UnitModel unitModel;
        protected UnitView unitView;

        public virtual void OnEnter( UnitModel model, UnitView view )
        {
            this.unitModel = model;
            model.OnEnter();
            if( this.unitView == null ) {
                this.unitView = GetComponentInChildren<UnitView>();
            }
            this.unitView.OnEnter( this, model );
        }

        public virtual void OnExit()
        {
            unitModel.OnExit();
            unitView.OnExit();
        }

        public virtual void Process()
        {
            unitModel.Process();
            unitView.Process();
        }
    }
}