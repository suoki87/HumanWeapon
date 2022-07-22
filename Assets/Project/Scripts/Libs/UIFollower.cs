using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
	/// <summary>
    /// 대상이 있으면 대상을 따라다니는 UI ( HUD )
    /// </summary>
    public class UIFollower : MonoBase
	{
		private RectTransform rect;
    	[HideInInspector] public Transform target = null;

    	private Camera _mainCam;
    	private Camera _uiCam;

    	private void Awake()
    	{
            rect = GetComponentInParent<RectTransform>();
        }

        public void OnEnter( Transform target )
        {
	        this.target = target;
	        if ( _mainCam == null ) _mainCam = CameraMan.In.mainCam;
	        if( _uiCam == null ) _uiCam = CameraMan.In.uiCam;
	        SetPos();
        }

        public void OnExit()
        {
	        target = null;
        }

        //Late Update 에서 처리해줘야 부드럽다.
        public void LateUpdate()
        {
	        if ( target && _uiCam != null && _mainCam != null ) {
		        Follow();
	        }
        }

        public void SetPos()
    	{
    		if ( target && _uiCam != null && _mainCam != null ) {
    			Follow();
    		}
    	}

    	/// <summary>
    	/// 월드좌표를 스크린 좌표로.
    	/// https://wergia.tistory.com/213
    	/// </summary>
    	private void Follow()
    	{
	        cTrf.position = TransformCameraWorldPoint( _mainCam, _uiCam, target.position );
    	}

        public Vector3 TransformCameraWorldPoint(Camera mainCam, Camera uiCam, Vector3 position)
        {
	        Vector3 viewport = mainCam.WorldToViewportPoint(position);
	        return uiCam.ViewportToWorldPoint(viewport);
        }
	}
}