using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public class UnitModel : IModel
    {
        protected Unit unit;
        public string key;

        public UnitModel( Unit unit, string key )
        {
            this.unit = unit;
            this.key = key;
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual void Process()
        {

        }
    }
}