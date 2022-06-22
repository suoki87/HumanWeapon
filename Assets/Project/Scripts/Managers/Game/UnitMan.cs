using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actor;

public class UnitMan : SingletonMonoDestroy<UnitMan>
{
    public List<Unit> units;
    public Hero hero;
    public List<Monster> monsters;

    public void OnEnter()
    {
        units = new List<Unit>();
        monsters = new List<Monster>();

        hero = null;
    }

    public void OnExit()
    {
        monsters.Clear();
        units.Clear();
        hero = null;
    }

    public void SpawnUnit( Unit unit )
    {
        if( units.Contains( unit ) ) {
            return;
        }

        units.Add( unit );

        if( unit is Hero ) {
            hero = unit as Hero;
        }

        if( unit is Monster ) {
            monsters.Add( unit as Monster);
        }
    }

    public void Process()
    {
        foreach( var unit in units )
        {
            unit.Process();
        }
    }
}