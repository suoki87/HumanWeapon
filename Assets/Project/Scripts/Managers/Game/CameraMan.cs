using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : SingletonMonoDestroy<CameraMan>
{
    public Camera mainCam;
    public Camera uiCam;

    public Vector3 origin = new Vector3( 0f, 1.8f, -10f );
    public Transform trf;

    private void LateUpdate()
    {
        FollowHero();
    }

    void FollowHero()
    {
        var hero = UnitMan.In.hero;
        if( hero != null ) {
            trf.position = new Vector3( hero.position.x, origin.y, origin.z );
        }
    }

    //이건 계산된 최종값을 월드 포지션(position)에 넣어야함.
    public Vector3 WorldToScreen(Vector3 position)
    {
        Vector3 viewport = mainCam.WorldToViewportPoint(position);
        return uiCam.ViewportToWorldPoint(viewport);
    }

    //이건 계산된 최종 값을 localposition 에 넣어야함.
    public Vector3 WorldToScreen( RectTransform rect, Vector3 pos )
    {
        Vector3 screenPos = mainCam.WorldToScreenPoint( pos );
        RectTransformUtility.ScreenPointToLocalPointInRectangle( rect, screenPos, mainCam, out Vector2 localPos );
        return localPos;
    }
}