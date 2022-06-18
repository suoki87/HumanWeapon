using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Actor;

public class UnitMan : SingletonMonoDestroy<UnitMan>
{
    public List<Unit> units;

    protected override void OnAwake()
    {
        base.OnAwake();
        units = new List<Unit>();
    }

    protected override void OnDestroy()
    {
        units.Clear();
        base.OnDestroy();
    }
}