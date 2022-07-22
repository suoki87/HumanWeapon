using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDataEditor;

//GDE Usage
//초기화
//GDEDataManager.Init( "gde_data" );
//모든데이터.
//List<GDEHorseData> _horseDatas = GDEDataManager.GetAllItems<GDEHorseData>();
//모든 KEY
//GDEItemKeys.Horse_Horse1
//랜덤얻기
//var data = GDEDataManager.GetRandom<GDEHorseData>();

namespace Tables
{
    public static class Table
    {
        public static Define Define => TableMan.In.define;
        public static Hero Hero => TableMan.In.hero;
        public static Monster Monster => TableMan.In.monster;
        public static Magic Magic => TableMan.In.magic;
        public static Item Item => TableMan.In.item;
    }

    public class TableMan : SingletonMono<TableMan>
    {
        public Define define;
        public Hero hero;
        public Monster monster;
        public Magic magic;
        public Item item;

        protected override void OnAwake()
        {
            base.OnAwake();
            Init();
        }

        public void Init()
        {
            GDEDataManager.Init( "gde_data" );

            //Todo 편의를 위해 인스턴싱을 여기서
            define = new Define();
            hero = new Hero();
            monster = new Monster();
            magic = new Magic();
            item = new Item();
        }
    }

    public abstract class TableDataBase<T> where T : IGDEData
    {
        public Dictionary<string, T> datas;
        public List<T> lists;

        protected TableDataBase()
        {
            Init();
        }

        public virtual void Init()
        {
            lists = GDEDataManager.GetAllItems<T>();
            datas = new Dictionary<string, T>();
            foreach( var data in lists )
            {
                datas.Add( data.Key, data );
            }
        }

        public virtual T Get( string key )
        {
            if( datas.TryGetValue( key, out var value ))
            {
                return value;
            }
            Debug.LogErrorFormat( $"Key is Wrong {key} " );
            return null;
        }

        public virtual T Get( int index )
        {
            return lists[index];
        }
    }
}