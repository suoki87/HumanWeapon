using System.Collections;
using System.Collections.Generic;
using Actor;
using UI;
using UnityEngine;

public class ObjectMan : SingletonMonoDestroy<ObjectMan>
{
    public GameObject pfHero;
    public GameObject pfMonster;
    public GameObject pfDmg;
    public GameObject pfHpBar;

    public Hero SpawnHero()
    {
        return pfHero.MakeInstance<Hero>( WorldHolder.In.Holder );
    }

    public Monster SpwawnMonster()
    {
        return pfMonster.MakeInstance<Monster>( WorldHolder.In.Holder );
    }

    public HUDDamage SpawnDmg()
    {
        return pfDmg.MakeInstance<HUDDamage>( WorldHolder.In.Holder );
    }

    public HPBar SpawnHpBar()
    {
        return pfHpBar.MakeInstance<HPBar>( WorldHolder.In.hudHolder );
    }
}