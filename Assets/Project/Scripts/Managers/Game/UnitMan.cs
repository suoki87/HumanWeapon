using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actor;

public class UnitMan : SingletonMonoDestroy<UnitMan>
{
    public List<Unit> units;
    public Hero hero;
    public List<Monster> monsters;
    public List<Magic> magics;

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
        units.Remove( unit );

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
        units.ForReverse( (unit) =>
        {
            unit.Process();
        } );
    }

    public Monster GetNearestMonster()
    {
        Monster target = null;
        float minDistance = float.MaxValue;
        foreach( var monster in monsters )
        {
            if( monster.IsAlive() == false ) {
                continue;
            }

            var distance = Vector3.Distance( hero.position, monster.position );
            if( distance < minDistance )
            {
                minDistance = distance;
                target = monster;
            }
        }
        return target;
    }



}