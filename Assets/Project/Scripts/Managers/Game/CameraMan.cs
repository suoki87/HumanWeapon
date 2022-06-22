using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMan : SingletonMonoDestroy<CameraMan>
{
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
}