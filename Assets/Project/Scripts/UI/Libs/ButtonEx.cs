using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using DG.Tweening;

namespace UI
{
	[RequireComponent( typeof( Button ) )]
	[RequireComponent( typeof( Image ) )]
	public class ButtonEx : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
	{
		public RectTransform scaleTarget;
		public float scaleVal = 1.1f;
		public string ClickSound = "10000";
		public Button button;

		Coroutine _playbtnAniCo;
		bool _buttonPressed;

		void Reset()
		{
			if ( scaleTarget == null )
				scaleTarget = GetComponent<RectTransform>();

			if ( button == null ) {
				button = GetComponent<Button>();
				button.transition = Selectable.Transition.None;
			}
		}

		void OnDisable()
		{
			if ( _playbtnAniCo != null )
				StopCoroutine( _playbtnAniCo );

			if ( scaleTarget != null ) {
				scaleTarget.DOKill( true );
				scaleTarget.localScale = Vector3.one;
			}
		}

		IEnumerator PlayButtonAni()
		{
			scaleTarget.DOKill( true );
			yield return scaleTarget.DOScale( Vector3.one * scaleVal, 0.11f ).SetUpdate(true).SetEase( Ease.InOutQuad ).WaitForCompletion();

			while( _buttonPressed ) {
				yield return null;
			}
			yield return scaleTarget.DOScale( Vector3.one, 0.21f ).SetUpdate( true ).SetEase( Ease.OutBack, 4.4f ).WaitForCompletion();
			_playbtnAniCo = null;
		}

		public void OnPointerDown( PointerEventData eventData )
		{
			_buttonPressed = true;
			if( button.IsInteractable() && scaleTarget != null )
			{
				if( _playbtnAniCo != null ) StopCoroutine( _playbtnAniCo );
				_playbtnAniCo = StartCoroutine( PlayButtonAni() );
			}
		}

		public void OnPointerUp( PointerEventData eventData )
		{
			_buttonPressed = false;
			if( button.IsInteractable() )
			{
				// if( ClickSound.IsOk() && SoundMan.HasInstance ) {
				// 	SoundMan.In.PlayOneshot( ClickSound );
				// }
			}
		}
	}
}