using UnityEngine;
using DG.Tweening;
using TMPro;

namespace UI
{
    public class HUDDamage : MonoBase
    {
        private Tween jumpTween;
        private Tweener fadeTween;

        public Transform holder;
        public TextMeshPro txtDmg;
        public float animTime = 1.5f;

        private void Awake()
        {
            jumpTween = holder.DOLocalJump(
                new Vector3(
                    0f,// Rands.Range( -2f, 2f ),
                    Rands.Range( 0.5f, 1f ), 0f ),
                Rands.Range( 0.5f, 1f ), 1,
                animTime ).SetAutoKill(false).Pause();

            fadeTween = txtDmg.DOFade( 0, animTime * 0.5f ).SetEase( Ease.InCirc )
                .SetAutoKill(false).Pause();
        }

        public void OnEnter(Vector3 pos)
        {
            position = pos;
            localScale = Vector3.one;
            holder.localPosition = Vector3.zero;
            Invoke( nameof(OnExit), animTime );
        }

        public void OnExit()
        {
            fadeTween.Pause();
            jumpTween.Pause();

            CancelInvoke( nameof(OnExit) );

            Destroy( gameObject );
        }

        private void OnDestroy()
        {
            fadeTween.Kill(true);
            jumpTween.Kill(true);
        }

        public void ShowDamage( string text )
        {
            ShowDamage( text, Color.white );
        }

        public void ShowDamage( string text, Color col )
        {
            txtDmg.SetText( text );
            txtDmg.color = col;

            jumpTween.Restart();
            fadeTween.Restart();
        }

        public static HUDDamage Spawn(Vector3 pos, string dmgTxt, Color col )
        {
            var dmg = ObjectMan.In.SpawnDmg();
            dmg.OnEnter( pos );
            dmg.ShowDamage( dmgTxt, col );
            return dmg;
        }
    }
}