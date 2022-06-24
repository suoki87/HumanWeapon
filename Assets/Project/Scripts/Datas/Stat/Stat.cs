using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStatDataHandler
{
    Stat stat { get; set; }
}

public abstract class Stat
{
    protected DicStat _stats;
    protected IStatDataHandler _dataHandler;
    protected bool isDirty;
    private DicStat stats {
        get {
            if (isDirty == true) {
                CalcStats();
                isDirty = false;
            }
            return _stats;
        }
    }

    public float this[STAT kind]
    {
        get { return stats[kind]; }
        set { stats[kind] = value; }
    }

    protected Stat(IStatDataHandler dataHandler)
    {
        _dataHandler = dataHandler;
        NewStats();
        CalcStats();
        isDirty = false;
    }

    protected abstract void NewStats();
    protected abstract void CalcStats();

    public abstract void ReFill();

    public void SetDirty()
    {
        isDirty = true;
    }
}