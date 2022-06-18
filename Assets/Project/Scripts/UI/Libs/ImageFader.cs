using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent( typeof( Image ) )]
public class ImageFader : MonoBehaviour
{
	[Range(0, 1f)]
	public float startValue = 0f;
	[Range( 0, 1f )]
	public float endValue = 0.7f;

	public Ease ease = Ease.InOutSine;

	public float startDelay = 0f;
	public float fadeTime = 1f;
	Image render;

	private void Awake()
	{
		if ( render is null )
			render = GetComponent<Image>();
	}

	private void OnEnable()
	{
		render.SetAlpha( startValue );
		render.DOKill( true );
		render.DOFade( endValue, fadeTime ).SetEase( ease ).SetLoops( -1, LoopType.Yoyo ).SetDelay( startDelay );
	}

	private void OnDisable()
	{
		render.SetAlpha( startValue );
		render.DOKill( true );
	}
}