using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public abstract class UIObject : MonoBehaviour
    {
        public virtual void OnOpen( object param = null)
        {

        }

        public virtual void OnClose()
        {

        }
    }
}