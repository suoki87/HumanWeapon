using System;
using System.Collections;
using System.Collections.Generic;
using PlayCore;
using Tables;
using UnityEngine;

namespace Actor
{
    public class Magic : Character
    {
        protected MagicView View;
        protected MagicModel Model;

        private Character _target;

        public enum State
        {
            Idle,
            Move,
            Burst,
        }

        public State _state;

        public override void OnEnter( UnitModel model )
        {
            base.OnEnter( model );
            Model = unitModel as MagicModel;
            View = unitView as MagicView;
            _state = State.Idle;
        }

        public void Shot( Character target, Vector3 startPos, Vector3 targetPos )
        {
            position = startPos;
            Model.Shot( startPos, targetPos );
            _state = State.Move;
            _target = target;
        }

        public override void Process()
        {
            if( _state != State.Move )
                return;

            MoveProcess();
        }


        void MoveProcess()
        {
            var tbl = Model.tblData;
            var moveType = Table.Magic.GetMoveType( Model.key );
            var speed = tbl.mov / 20f;
            switch( moveType )
            {
                case Tables.Magic.MoveType.Linear:
                    position = Move( EaseType.Linear, Model.startPos, Model.targetPos, Model.shotTick, speed);
                    Model.shotTick += Time.deltaTime;
                    if( Model.shotTick >= speed )
                    {
                        _state = State.Burst;

                        if( _target != null && _target.isActiveAndEnabled && _target.IsAlive() )
                        {
                            //몬스터가 죽지 않으면 플레이어를 피격.
                            if( _target.TryGetComponent( out IHittable hitter ) ) {
                                hitter.OnHit( this, Model.tblData.atk, HitType.Magic );
                            }
                        }

                        View.OnBurst();
                        Destroy( gameObject );
                        // OnExit();
                    }
                    break;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}