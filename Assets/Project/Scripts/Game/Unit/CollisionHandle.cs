using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Actor
{
    public interface ICollidable
    {
        void OnEnterTrigger( Unit target );
        void OnExitTrigger( Unit target );
    }

    /// <summary>
    /// 유닛간의 콜라이더 감지 처리.
    /// </summary>
    public class CollisionHandle : MonoBehaviour
    {
        public LayerMask mask;
        public ICollidable owner;

        private void Awake() {
            owner = GetComponent<ICollidable>();
        }

        bool IsInLayerMask( Collider2D other )
        {
            return ( mask.value & ( 1 << other.gameObject.layer ) ) > 0;
        }

        protected virtual void OnTriggerEnter2D( Collider2D other )
        {
            if( IsInLayerMask( other ) == false )
                return;

            if( other.TryGetComponent( out Unit target ) ) {
                owner.OnEnterTrigger( target );
            }
        }

        protected virtual void OnTriggerExit2D( Collider2D other )
        {
            if( IsInLayerMask( other ) == false )
                return;

            if( other.TryGetComponent( out Unit target ) ) {
                owner.OnExitTrigger( target );
            }
        }
    }
}