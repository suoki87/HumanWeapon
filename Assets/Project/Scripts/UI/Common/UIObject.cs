using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class UIObject : MonoBehaviour
    {
        private UIKind kind;

        public virtual void OnOpen( object param = null)
        {

        }

        public virtual void OnClose()
        {

        }

        public virtual void Close()
        {
            UIMan.In.Close( this );
        }
    }
}