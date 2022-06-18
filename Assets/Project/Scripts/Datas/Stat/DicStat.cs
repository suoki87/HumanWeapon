using System.Collections.Generic;

/// <summary>
/// 디셔너리형 스탯 컨테이너 < float >
/// </summary>
public class DicStat : Dictionary<STAT, float>
{
	public DicStat() : base() { }
	public DicStat( int capacity ) : base( capacity ) { }
	public DicStat( Dictionary<STAT, float> src ) : base( src ) { }
	public DicStat( DicStat src ) : base( src  ) { }

	new public float this[STAT kind] {
		get { return Get( kind ); }
		set { base[kind] = value; }
	}

	#region Get, Set, Add, Sub

	public float AddVal( STAT kind, float value ) { return Set( kind, Get( kind ) + value ); }
	public float SubVal( STAT kind, float value ) { return Set( kind, Get( kind ) - value ); }

	public float Get( STAT kind )
	{
		if ( TryGetValue( kind, out var value ) == true ) return value;
		else { Add( kind, 0 ); }
		return 0;
	}

	public float Set( STAT kind, float value )
	{
		return (base[kind] = value);
	}

	void RemoveSafe( STAT kind )
	{
		if ( ContainsKey( kind ) == true ) {
			Remove( kind );
		}
	}

	//키가 있는경우만 넣고 싶을때는 onlykey = true
	public float AddVal( STAT kind, float value, bool onlyKey = false )
	{
		if ( onlyKey == true && !this.TryGetValue( kind, out var val ) )
			return val;
		return Set( kind, Get( kind ) + value );
	}

	public float SubVal( STAT kind, float value, bool onlyKey = false )
	{
		if ( onlyKey == true && !this.TryGetValue( kind, out var val ) )
			return val;
		return Set( kind, Get( kind ) - value );
	}


	public DicStat AddVals( DicStat r )
	{
		foreach ( var pair in r ) {
			AddVal( pair.Key, pair.Value );
		}
		return this;
	}

	public DicStat SubVals( DicStat r )
	{
		foreach ( var pair in r ) {
			SubVal( pair.Key, pair.Value );
		}
		return this;
	}
	#endregion

}