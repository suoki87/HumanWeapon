using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent( typeof( Image ) )]
public class ImageScaler : MonoBehaviour
{
	[Range( 0, 5f )]
	public float randomStartDelay = 0f;
	public float scaleEndValue = 1.1f;
	public float duration = 2f;

	Transform _transform;

	private void Reset()
	{
		if ( _transform is null )
			_transform = transform;
	}

	private void Awake()
	{
		if ( _transform is null )
			_transform = transform;
	}

	private void OnEnable()
	{
		_transform.DOKill( true );
		_transform.DOScale( scaleEndValue, duration )
			.SetLoops( -1, LoopType.Yoyo )
			.SetDelay( Rands.Range( 0f, randomStartDelay ) );
	}

	private void OnDisable()
	{
		_transform.DOKill( true );
	}
}
