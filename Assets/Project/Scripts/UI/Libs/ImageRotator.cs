using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent( typeof( Image ) )]
public class ImageRotator : MonoBehaviour
{
	[Range(0, 5f)]
	public float randomDelay;
	public float rotTime = 5f;
	public bool clockWise = true;

	Transform _transform;

	private void Awake()
	{
		_transform = transform;
	}

	private void OnEnable()
	{
		int dir = clockWise == true ? -1 : 1;
		_transform.DOKill( true );
		_transform.DOLocalRotate( Vector3.forward * 360f * dir, rotTime, RotateMode.LocalAxisAdd )
			.SetLoops( -1, LoopType.Incremental )
			.SetDelay( Rands.Range(0f, randomDelay) );
	}

	private void OnDisable()
	{
		_transform.DOKill( true );
	}
}
