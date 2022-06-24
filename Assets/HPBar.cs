using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HPBar : MonoBase
    {
        public TMP_Text textHp;
        public Image bar;
        public UIFollower follower;
        public CanvasGroup cg;
        public void OnEnter(Transform target)
        {
            follower.OnEnter( target );
            cg.alpha = 1f;
        }

        public void OnExit()
        {
            cg.alpha = 0f;
            follower.OnExit();
        }

        public void OnRefresh(float cur, float max)
        {
            textHp.text = string.Format( "{0:0.#}", cur );
            bar.fillAmount = cur / max;
        }
    }
}