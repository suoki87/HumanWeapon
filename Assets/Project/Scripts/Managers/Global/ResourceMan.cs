using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

/// <summary>
/// 모든 리소스는 여기서 관리.
/// </summary>
public class ResourceMan : SingletonMono<ResourceMan>
{
    public const string PATH_PREFAB = "Prefabs/";

    public SpriteAtlas atlas;

    private Dictionary<string, GameObject> _prefabs = new Dictionary<string, GameObject>();

    protected override void OnAwake()
    {
        base.OnAwake();
        LoadAll();

    }

    public void LoadAll()
    {
        //프리팹 전체 로드.
        LoadAllResource<GameObject>( "Prefabs", _prefabs );
    }

    public GameObject GetPrefab( string name )
    {
        if ( _prefabs.TryGetValue( name, out GameObject obj ) ) {
            return obj;
        } else {
            obj = Resources.Load<GameObject>( PATH_PREFAB + name );
            if( obj == null ) {
                Debug.LogErrorFormat( $"ResourceLoad Fail! {name}" );
                return null;
            }
            _prefabs.Add( name, obj );
            return obj;
        }
    }

    /// 프리팹 리소스를 로드하고 인스턴싱까지 해서 뱉어준다.
    /// path 는 Resouces 에서의 하위 폴더 경로.
    public T GetInstance<T>( string name, Transform parent = null) where T : Component
    {
        var prefab = GetPrefab( name );
        return prefab.MakeInstance<T>( parent );
    }


    public int LoadAllResource<T>( string folder, Dictionary<string, T> dics) where T : Object
    {
        int loadCount = 0;
        T[] res = Resources.LoadAll<T>( folder ) as T[];
        foreach ( var item in res ) {
            if ( item != null ) {
                dics.Add( item.name, item );
                loadCount++;
            } else {
                Debug.LogErrorFormat( $"Check Resource Folder Name : {folder}");
            }
        }
        Debug.LogFormat( $" LoadAllResource : {folder} {loadCount}" );
        return loadCount;
    }

    public Sprite GetSprite( string spriteName )
    {
        var sprite = atlas.GetSprite( spriteName );
        if( sprite == null ) {
            Log.to.E( $"Wrong Sprite - {spriteName}" );
        }
        return sprite;
    }
}