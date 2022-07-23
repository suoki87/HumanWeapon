using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actor;
using Sirenix.Utilities;

public class UnitMan : SingletonMonoDestroy<UnitMan>
{
    public List<Unit> units;
    public Hero hero;
    public List<Monster> monsters;
    public List<Magic> magics;
    public List<Unit> removables;       //삭제 예정목록

    public void OnEnter()
    {
        units = new List<Unit>();
        monsters = new List<Monster>();
        magics = new List<Magic>();

        hero = null;
    }

    public void OnExit()
    {
        magics.Clear();
        monsters.Clear();
        units.Clear();
        hero = null;
    }

    public void AddUnit( Unit unit )
    {
        if( units.Contains( unit ) ) {
            return;
        }

        #if UNITY_EDITOR
        Log.to.I($"AddUnit {unit.name}");
        if( units.Contains( unit ) ) {
            Log.to.E($"이미있는 unit {unit.name}");
        }
        #endif

        units.Add( unit );

        if( unit is Hero ) {
            hero = unit as Hero;
        }

        if( unit is Monster monster ) {
            monsters.Add( monster);
        }

        if( unit is Magic magic )
        {
            magics.Add( magic );
        }
    }

    public void RemoveUnit( Unit unit )
    {

#if UNITY_EDITOR
        Log.to.I($"RemoveUnit {unit.name}");
        if( units.Contains( unit ) == false) {
            Log.to.E($"없는 unit {unit.name}");
        }
#endif
        removables.Add( unit );
        //units.Remove( unit );

        if( unit is Hero ) {
            hero = null;
        }

        if( unit is Monster monster ) {
            monsters.Remove( monster);
        }

        if( unit is Magic magic ) {
            magics.Remove( magic );
        }
    }


    public void Process()
    {
        if( removables.Count > 0 )
        {
            foreach( var target in removables ) {
                units.Remove( target );
            }
            removables.Clear();
        }

        units.ForReverse( (unit) =>
        {
            unit.Process();
        } );
    }

    public Monster GetNearestMonster(float limitDistance = 5f)
    {
        Monster target = null;
        float minDistance = float.MaxValue;
        foreach( var monster in monsters )
        {
            if( monster.IsAlive() == false ) {
                continue;
            }
            var distance = Vector3.Distance( hero.position, monster.position );
            if( distance >= limitDistance ) {
                continue;
            }
            if( distance < minDistance )
            {
                minDistance = distance;
                target = monster;
            }
        }
        return target;
    }



}