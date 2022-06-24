using System.Collections;
using System.Collections.Generic;
using Actor;
using UnityEngine;

public class ObjectMan : SingletonMonoDestroy<ObjectMan>
{
    public GameObject pfHero;
    public GameObject pfMonster;

    public Hero SpawnHero()
    {
        return pfHero.MakeInstance<Hero>( WorldHolder.In.Holder );
    }

    public Monster SpwawnMonster()
    {
        return pfMonster.MakeInstance<Monster>( WorldHolder.In.Holder );
    }
}