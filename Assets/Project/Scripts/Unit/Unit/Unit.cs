using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public enum UnitKind
    {
        Hero,
        Monster,
    }

    public class Unit : MonoBase
    {
        protected UnitModel unitModel;
        protected UnitView unitView;

        public virtual void OnEnter( UnitModel model )
        {
            this.unitModel = model;
            model.OnEnter();
            if( this.unitView == null ) {
                this.unitView = GetComponentInChildren<UnitView>();
            }
            this.unitView.OnEnter( this, model );
            UnitMan.In.AddUnit( this );
        }

        public virtual void OnExit()
        {
            unitModel.OnExit();
            unitView.OnExit();

            UnitMan.In.RemoveUnit( this );
        }

        public virtual void Process()
        {
            unitModel.Process();
            unitView.Process();
        }
    }
}