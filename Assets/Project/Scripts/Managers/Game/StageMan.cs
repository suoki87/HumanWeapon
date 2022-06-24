using System;
using System.Collections;
using System.Collections.Generic;
using Actor;
using Data;
using GameDataEditor;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMan : SingletonMonoDestroy<StageMan>
{
    public enum State
    {
        None,
        Idle,
        Run,
    }

    public State state = State.None;
    private Coroutine stageStartCo = null;

    public int monsterCount = 0;

    public Pan_Game uiGame;

    public void OnEnter()
    {
        //씬 자동 전환때문에 여기에 한번 오고 Title 로 가는 경우 걸러야함.
        if( state != State.None )
            return;

        state = State.Idle;
        UnitMan.In.OnEnter();

        if( stageStartCo != null ) StopCoroutine( stageStartCo );
        stageStartCo = StartCoroutine( StartStageCo() );

        Broadcaster.EnableListener( EventName.OnStatLvUp, OnHeroLvUp );
    }

    public void OnExit()
    {
        uiGame.OnClose();
        Broadcaster.DisableListener( EventName.OnStatLvUp, OnHeroLvUp );
        UnitMan.In.OnExit();
    }

    private void OnHeroLvUp()
    {
        UnitMan.In.hero.OnLvUp();
    }

    IEnumerator StartStageCo()
    {
        GenerateStage( DataMan.In.stageNo );
        uiGame.OnOpen( null );
        yield return YieldCache.WaitForSeconds( 0.5f );
        OnPlay();
    }

    void GenerateStage( int stageNo )
    {
        GenerateHero();
        GenerateMonsters( stageNo );
    }

    void GenerateHero()
    {
        var hero = ObjectMan.In.SpawnHero();
        var model = new HeroModel( hero, GDEItemKeys.Hero_Hero_1 );
        hero.OnEnter( model );

        Util.TransformIdentityLocal( hero.transform, WorldHolder.In.Holder );
    }

    void GenerateMonsters(int stageNo)
    {
        // stageNo + GroupNo 로 밸런싱.
        // 1 1 1 1 1  2 2 2 2   3 3 3  4 4  5  BOSS
        //최대거리 200
        //그룹 6
        //그룹당 최대 5마리
        //그룹내 간격은 1m
        //그룹간 간격은 5m

        const int GroupCount = 6;
        const float StartX = 10f;
        const float GroupDistance = 10f;
        const float UnitDistance = 2f;

        for( int i = 0; i < GroupCount; i++ )
        {
            int monsterCountInGroup = i + 1;
            for( int j = 0; j < monsterCountInGroup; j++ )
            {
                var monster = ObjectMan.In.SpwawnMonster();
                var model = new MonsterModel( monster, GDEItemKeys.Monster_Monster_1 );
                int groupNo = i + 1;
                model.SetData( stageNo, groupNo );
                monster.OnEnter( model );

                float x = StartX + ( i * GroupDistance ) + ( j * UnitDistance );
                monster.position = new Vector3( x, 0f, 0f );
                monsterCount++;
            }
        }
    }

    public void OnPlay()
    {
        state = State.Run;

        UnitMan.In.hero.OnPlay();
    }

    public void Update()
    {
        if( state == State.Run )
        {
            UnitMan.In.Process();
        }
    }

    public void OnHeroDie()
    {
        StageMan.In.OnExit();
        SceneManager.LoadScene( "Game" );
    }

    public void OnMonsterDie()
    {
        monsterCount--;

        DataMan.In.gold += Logic_Game.GetDropGold( DataMan.In.stageNo );

        Broadcaster.SendEvent( EventName.OnMonsterDie );

        if( monsterCount <= 0 )
        {
            DataMan.In.stageNo++;
            SceneManager.LoadScene( "Game" );
        }
    }
}