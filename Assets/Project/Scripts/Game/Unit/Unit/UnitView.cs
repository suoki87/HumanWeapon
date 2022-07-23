using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Actor
{
    public class UnitView : MonoBase, IView
    {
        protected Unit unit;
        protected UnitModel unitModel;
        protected SortingGroup sorting;

        public Transform body;
        public Transform bottom;

        protected virtual void Awake()
        {
            sorting = gameObject.GetSmartComponent<SortingGroup>();
        }

        public virtual void OnEnter( Unit unit, UnitModel model )
        {
            this.unit = unit;
            this.unitModel = model;
        }

        public virtual void OnExit()
        {
            sorting.sortingOrder = 0;
        }

        public virtual void Process()
        {

        }

        public virtual void ZSort()
        {
            //sorting.sortingOrder = Screen.height - Mathf.RoundToInt(bottom.position.y * 200f);
        }

    }
}