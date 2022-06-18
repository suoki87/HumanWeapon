using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DG.Tweening;

public static class Tools
{
	public static bool Approximately( this double value1, double value2, double delta = 0.00001d )
	{
		return Math.Abs( value1 - value2 ) <= delta;
	}

	public static string PathCombine( params string[] paths )
	{
		string res = paths[0];
		for ( int i = 1; i < paths.Length; i++ ) {
			res = System.IO.Path.Combine( res, paths[i] );
		}
		return res;
	}

	[System.Diagnostics.Conditional( "DEBUG" )]
	public static void DumpDelegates( UnityEngine.Object owner, Delegate del, StringBuilder sb )
	{
		if ( del == null )
			return;
		var dels = del.GetInvocationList();
		for ( int i = 0; i < dels.Length; i++ ) {
			sb.AppendFormat( "{0}.{1} : {2}.{3}\n", owner, del.Method, dels[i].Target, dels[i].Method );
			if ( dels[i].Target == null ) {
				Debug.LogWarningFormat( owner, "Delegate target is null! - {0}.{1} : {2}.{3}", owner, del.Method, dels[i].Target, dels[i].Method );
			}
		}
	}

	[System.Diagnostics.Conditional( "DEBUG" )]
	public static void DumpDelegates( UnityEngine.Object owner, Delegate del )
	{
		var sb = new StringBuilder( 1000 );
		DumpDelegates( owner, del, sb );
		Debug.LogFormat( owner, sb.ToString() );
	}

	public static string ToXOR( this string str, int key )
	{
		string newText = string.Empty;
		for ( int i = 0; i < str.Length; i++ ) {
			int charVal = Convert.ToInt32( str[i] ); //get the ASCII value of the character
			charVal ^= key; //xor the value
			newText += char.ConvertFromUtf32( charVal ); //convert back to string
		}
		return newText;
	}

	public static T First<T>( IEnumerable<T> items )
	{
		using ( IEnumerator<T> iter = items.GetEnumerator() ) {
			if ( iter.MoveNext() )
				return iter.Current;
			return default( T );
		}
	}

	public static T Last<T>( IEnumerable<T> items )
	{
		T lastOne = default( T );
		if ( items != null ) {
			foreach ( var item in items ) {
				lastOne = item;
			}
		}
		return lastOne;
	}

	/// <summary>
	/// 문자열을 TEnum 타입으로 변환한다. 만약 없으면 Exception 발생.
	/// </summary>
	public static TEnum ToEnum<TEnum>( this string strEnumValue ) where TEnum : struct, Enum
	{
		return (TEnum)Enum.Parse( typeof( TEnum ), strEnumValue );
	}

	/// <summary>
	/// 문자열을 TEnum 타입으로 변환한다. 만약 없으면 defaultValue를 리턴.
	/// </summary>
	public static TEnum ToEnum<TEnum>( this string strEnumValue, TEnum defaultValue ) where TEnum : struct, Enum
	{
		return Enum.TryParse( strEnumValue, out TEnum parsedEnum ) ? parsedEnum : defaultValue;
	}

	/// <summary>
	/// 랜덤한 enum 얻기  0 ~ n 으로 구성되어야하며 None Max 같은 형이 들어있지않아야 제대로 작동함.
	/// </summary>
	/// <typeparam name="TEnum"></typeparam>
	/// <returns></returns>
	public static TEnum RandomEnum<TEnum>()
	{
		Array values = Enum.GetValues( typeof( TEnum ) );
		return (TEnum)values.GetValue( new System.Random().Next( 0, values.Length ) );
	}

	/// <summary>
	/// 배정도형 실수를 반올림 정수로 반환한다. 반올림은 Javascript의 round와 동일한 방식을 취한다.
	/// </summary>
	public static int RoundToInt( double val )
	{
		return (int)Math.Round( val, MidpointRounding.AwayFromZero );
	}

	public static Vector3 MaskX( this Vector3 v, float x ) { v.x = x; return v; }
	public static Vector3 MaskY( this Vector3 v, float y ) { v.y = y; return v; }
	public static Vector3 MaskZ( this Vector3 v, float z ) { v.z = z; return v; }
	public static Vector3 MaskXZ( this Vector3 v, float x, float z ) { v.x = x; v.z = z; return v; }
	public static Vector3 MaskYZ( this Vector3 v, float y, float z ) { v.y = y; v.z = z; return v; }

	public static Color MaskAlpha( this Color c, float a ) { c.a = a; return c; }

	public static void SetRenderOff( this GameObject go, bool isHidden = true )
	{
		Renderer[] renderers = go.GetComponentsInChildren<Renderer>();
		for ( int i = 0; i < renderers.Length; i++ ) {
			renderers[i].enabled = !isHidden;
		}
	}

	public const string COLTAG_RED = "red";
	public const string COLTAG_YELLOW = "yellow";

	public static string AddColorTag( this string str, string color )
	{
		return "<color=" + color + ">" + str + "</color>";
	}

	public static string ToStringComma( this int val )
	{
		return val.ToString( "N0" );
	}

	public static string ToStringSign( this int val )
	{
		return val.ToString( "+#;-#;0" );
	}

	/// <summary>
	/// 0~1사이의 알파값으로
	/// </summary>
	public static void SetAlpha( this Image image, float alpha )
	{
		var color = image.color;
		color.a = alpha;
		image.color = color;
	}

	//public static Tweener ApplyTimeScale( this Tweener tween, TimeScale.Clock clock ) {
	//	clock.RegisterTween( tween );
	//	tween.OnKill( ()=>{ clock.UnregisterTween( tween ); } );
	//	return tween;
	//}
	//public static Tweener ApplyPlayTime( this Tweener tween ) {
	//	PlayMan.playClock.RegisterTween( tween );
	//	tween.OnKill( ()=>{ PlayMan.playClock.UnregisterTween( tween ); } );
	//	return tween;
	//}
	//public static Sequence ApplyTimeScale( this Sequence seq, TimeScale.Clock clock ) {
	//	clock.RegisterTween( seq );
	//	seq.OnKill( ()=>{ clock.UnregisterTween( seq ); } );
	//	return seq;
	//}
	//public static Sequence ApplyPlayTime( this Sequence seq ) {
	//	PlayMan.playClock.RegisterTween( seq );
	//	seq.OnKill( ()=>{ PlayMan.playClock.UnregisterTween( seq ); } );
	//	return seq;
	//}

	public static void MoveToLayer( Transform root, int layer )
	{
		root.gameObject.layer = layer;
		foreach ( Transform child in root )
			MoveToLayer( child, layer );
	}

	#region Animation
	public static bool IsState( this Animator ani, int shortNameHash )
	{
		return (ani.GetCurrentAnimatorStateInfo( 0 ).shortNameHash == shortNameHash);
	}

	public static bool IsInState( this Animator ani, int shortNameHash )
	{
		return ani.GetCurrentAnimatorStateInfo( 0 ).shortNameHash == shortNameHash
			|| ani.GetNextAnimatorStateInfo( 0 ).shortNameHash == shortNameHash;
	}

	//현재 애니메이션을 특정 프레임의 시점으로 세팅 ( 속도를 0으로 넣으면 고정 ) 0번프레임으로 고정시킬때 주로 사용.
	public static void PlayWithSpeed( this Animator ani, string name, float normalizedTime, float speed = 1 )
	{
		if ( ani.enabled == false ) return;

		ani.speed = speed;
		ani.Play( name, 0, normalizedTime );
	}

	public static AnimatorStateInfo GetCurrentState( this Animator ani )
	{
		var curState = ani.GetCurrentAnimatorStateInfo( 0 );
		var nextState = ani.GetNextAnimatorStateInfo( 0 );
		return nextState.shortNameHash == 0 ? curState : nextState;
	}

	public static IEnumerator WaitAniState( this Animator ani, int hashedName )
	{
		yield return new WaitUntil( () => ani.IsState( hashedName ) );
	}

	public static IEnumerator WaitAniState( this Animator ani, string state )
	{
		int hashedName = Animator.StringToHash( state );
		yield return new WaitUntil( () => ani.IsState( hashedName ) );
	}

	public static IEnumerator WaitAniPlay( this Animator ani, float normalizedTime = 0.99f )
	{
		yield return new WaitUntil( () => ani.GetCurrentAnimatorStateInfo( 0 ).normalizedTime >= normalizedTime );
	}

	public static IEnumerator WaitAniStatePlay( this Animator ani, int hashedName, float normalizedTime = 0.99f )
	{
		yield return new WaitUntil( () => ani.IsState( hashedName ) );
		yield return new WaitUntil( () => ani.GetCurrentAnimatorStateInfo( 0 ).normalizedTime >= normalizedTime );
	}

	public static IEnumerator WaitAniStatePlay( this Animator ani, string state, float normalizedTime = 0.99f )
	{
		int hashedName = Animator.StringToHash( state );
		yield return new WaitUntil( () => ani.IsState( hashedName ) );
		yield return new WaitUntil( () => ani.GetCurrentAnimatorStateInfo( 0 ).normalizedTime >= normalizedTime );
	}
	#endregion

	/// <summary>
	/// 모든 객체들에게 메세지를 전송한다.
	/// 주의! disable된 객체들은 메세지를 받지 못함.
	/// </summary>
	public static void BroadcastAll( string func )
	{
		BroadcastAll<GameObject>( func );
	}

	/// <summary>
	/// component 객체들에게 메세지를 전송한다.
	/// 주의! disable된 객체들은 메세지를 받지 못함.
	/// </summary>
	public static void BroadcastAll<T>( string func )
	{
		GameObject[] gos = (GameObject[])GameObject.FindObjectsOfType( typeof( T ) );
		foreach ( GameObject go in gos ) {
			if ( go && go.transform.parent == null ) {
				go.BroadcastMessage( func, SendMessageOptions.DontRequireReceiver );
			}
		}
	}

	#region UI helpers
	/// <summary>
	/// UI 오브젝트를 화면 최상위로 끌어 올린다.
	/// (Transform Hierarchy상에서 가장 아래로 내린다.)
	/// 주의: Canvas의 tag 설정이 제대로 되어 있어야 함.
	/// </summary>
	public static void BringToFront( GameObject go )
	{
		GameObject pedigree = go;
		while ( !pedigree.CompareTag( "Canvas" ) ) {
			pedigree.transform.SetAsLastSibling();
			pedigree = pedigree.transform.parent.gameObject;
		}
	}

	/// <summary>
	/// sibling 오브젝트의 바로 밑으로 bringTarget을 가져온다.
	/// (hierarchy상의 바로 위)
	/// </summary>
	public static void BringBackOfSibling( GameObject sibling, GameObject bringTarget )
	{
		Transform sibTm = sibling.transform;
		int sibIdx = sibTm.GetSiblingIndex();
		int count = sibTm.parent.childCount;
		int tgtIdx = (sibIdx > 0 && sibIdx == count - 1) ? sibIdx - 1 : sibIdx;

		bringTarget.transform.SetSiblingIndex( tgtIdx );
	}

	/// <summary>
	/// RectTransform의 네 모서리 영역의 화면좌표를 계산한다.
	/// </summary>
	public static void CalcCornerOnScreen( Camera uiCam, RectTransform rt, Vector3[] res, float canvasScaleFactor = 1f )
	{
		rt.GetWorldCorners( res );
		for ( int i = 0; i < 4; i++ ) {
			res[i] = uiCam.WorldToScreenPoint( res[i] ) / canvasScaleFactor;
		}
	}
	#endregion

	/// <summary>
	/// Universal interface to help in the creation of Hashtables.
	/// </summary>
	/// <param name="args">
	/// A <see cref="System.Object[]"/> of alternating name value pairs.  For example "time",1,"delay",2...
	/// </param>
	/// <returns>
	/// A <see cref="Hashtable"/>
	/// </returns>
	public static Hashtable Hash( params object[] args )
	{
		Hashtable hashTable = new Hashtable( args.Length / 2 );
		if ( args.Length % 2 != 0 ) {
			UnityEngine.Debug.LogError( "Error: Hash requires an even number of arguments!" );
			return null;
		}
		int i = 0;
		while ( i < args.Length - 1 ) {
			hashTable.Add( args[i], args[i + 1] );
			i += 2;
		}
		return hashTable;
	}

	public static Dictionary<T, U> Dic<T, U>( params object[] args )
	{
		Dictionary<T, U> dic = new Dictionary<T, U>( args.Length / 2 );
		if ( args.Length % 2 != 0 ) {
			UnityEngine.Debug.LogError( "Error: Dic requires an even number of arguments!" );
			return null;
		}
		int i = 0;
		while ( i < args.Length - 1 ) {
			dic.Add( (T)args[i], (U)args[i + 1] );
			i += 2;
		}
		return dic;
	}

	public static Dictionary<string, string> DicStr( params object[] args )
	{
		Dictionary<string, string> dicStr = new Dictionary<string, string>( args.Length / 2 );
		if ( args.Length % 2 != 0 ) {
			UnityEngine.Debug.LogError( "Error: Dic requires an even number of arguments!" );
			return null;
		}
		int i = 0;
		while ( i < args.Length - 1 ) {
			dicStr.Add( args[i].ToString(), args[i + 1].ToString() );
			i += 2;
		}
		return dicStr;
	}

	/// <summary>
	/// Returns the hierarchy of the object in a human-readable format.
	/// </summary>

	static public string GetHierarchy( GameObject obj )
	{
		if ( obj == null ) return "";
		string path = obj.name;

		while ( obj.transform.parent != null ) {
			obj = obj.transform.parent.gameObject;
			path = obj.name + "\\" + path;
		}
		return path;
	}

	static public string GetFullPath( GameObject go )
	{
		return GetFullPath( go.transform );
	}
	static public string GetFullPath( Transform tm )
	{
		return tm.parent == null
			? tm.name : GetFullPath( tm.parent ) + "/" + tm.name;
	}

	/// <summary>
	/// Find all active objects of specified type.
	/// </summary>

	static public T[] FindActive<T>() where T : Component
	{
		return GameObject.FindObjectsOfType( typeof( T ) ) as T[];
	}


	/// <summary>
	/// Instantiate an object and add it to the specified parent.
	/// </summary>

	static public GameObject AddChild( GameObject parent, GameObject prefab )
	{
		GameObject go = GameObject.Instantiate( prefab ) as GameObject;
#if UNITY_EDITOR
		UnityEditor.Undo.RegisterCreatedObjectUndo( go, "Create Object" );
#endif
		if ( go != null && parent != null ) {
			Transform t = go.transform;
			t.parent = parent.transform;
			t.localPosition = Vector3.zero;
			t.localRotation = Quaternion.identity;
			t.localScale = Vector3.one;
			go.layer = parent.layer;
		}
		return go;
	}


	/// <summary>
	/// Get the rootmost object of the specified game object.
	/// </summary>

	static public GameObject GetRoot( GameObject go )
	{
		Transform t = go.transform;

		for (; ; )
		{
			Transform parent = t.parent;
			if ( parent == null ) break;
			t = parent;
		}
		return t.gameObject;
	}


#if UNITY_EDITOR || !UNITY_FLASH
	/// <summary>
	/// Execute the specified function on the target game object.
	/// </summary>

	static public void Execute<T>( GameObject go, string funcName ) where T : Component
	{
		T[] comps = go.GetComponents<T>();

		foreach ( T comp in comps ) {
#if !UNITY_EDITOR && (UNITY_WEBPLAYER || UNITY_FLASH || UNITY_METRO || UNITY_WP8 || UNITY_WP_8_1)
			comp.SendMessage(funcName, SendMessageOptions.DontRequireReceiver);
#else
			MethodInfo method = comp.GetType().GetMethod( funcName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic );
			if ( method != null ) method.Invoke( comp, null );
#endif
		}
	}

	/// <summary>
	/// Execute the specified function on the target game object and all of its children.
	/// </summary>

	static public void ExecuteAll<T>( GameObject root, string funcName ) where T : Component
	{
		Execute<T>( root, funcName );
		Transform t = root.transform;
		for ( int i = 0, imax = t.childCount; i < imax; ++i )
			ExecuteAll<T>( t.GetChild( i ).gameObject, funcName );
	}
#endif

	/// <summary>
	/// 소수부분의 자릿수를 알고싶을때 사용. ex) 0.334  => 3리턴. 0.15 => 2리턴.
	/// </summary>
	/// <param name="argument"></param>
	/// <returns></returns>
	static public int GetDecimalFiledCount( decimal argument )
	{
		return BitConverter.GetBytes( decimal.GetBits( argument )[3] )[2];
	}


	///BitFlag Check Add Remove //https://github.com/dotnet/runtime/issues/14084
	//static public bool HasFlag(this Enum flag, Enum val)
	//{
	//	return flag.HasFlag( val );
	//}
	//[Flags] enum DirtyFlags { X = 1, Y = 1 << 1, Z = 1 << 2 };
	//DirtyFlags dirtyFlags = DirtyFlags.X | DirtyFlags.Y | DirtyFlags.Z;
	// Setting a flag
	//	dirtyFlags |= DirtyFlags.X;
	// Removing a flag, this is harder to remember :(
	//dirtyFlags &= ^DirtyFlags.X;

	//[Flags] 이용.
	//https://blog.danggun.net/7926

	//예제코드.
	//https://github.com/dang-gun/DotNetSamples/blob/master/EnumBitFlags/Program.cs


	//스크린 좌표를 월드 좌표로 변환하기
	public static Vector3 ScreenToWorld(this Vector3 screnTargetPos )
	{
		return Camera.main.ScreenToWorldPoint( screnTargetPos );
	}

	//월드를 스크린 좌표로.
	public static Vector3 WorldToScreen(this Transform trf, RectTransform root, Camera mainCam )
	{
		Vector3 screenPos = mainCam.WorldToScreenPoint( trf.position );//스크린상의 위치
		RectTransformUtility.ScreenPointToLocalPointInRectangle( root, screenPos, mainCam, out Vector2 localPos );
		return localPos;
	}

	//The Fisher-Yates Shuffle
	//seed example : (int)System.DateTime.Now.Ticks & 0x0000FFFF
	public static T[] ShuffleArray<T>( T[] array, int seed )
	{
		System.Random prng = new System.Random( seed );
		for ( int i = 0; i < array.Length - 1; i++ ) {
			int randomIndex = prng.Next( i, array.Length );
			T tempItem = array[randomIndex];
			array[randomIndex] = array[i];
			array[i] = tempItem;
		}
		return array;
	}

	//HUD
	public static void WorldToScreen( Camera mainCam, Camera uicam, Transform trf, Vector3 targetPos )
	{
		trf.position = mainCam.WorldToScreenPoint( targetPos );
		Vector3 position = mainCam.WorldToViewportPoint( targetPos );
		trf.position = uicam.ViewportToWorldPoint( position );
		position = trf.localPosition;
		position.x = Mathf.RoundToInt( position.x );
		position.y = Mathf.RoundToInt( position.y );
		position.z = 0.0f;
		trf.localPosition = position;
	}

	public static string MakeTimeText( int hour, int min, int sec )
	{
		if ( sec >= 60 ) {
			int div = sec / 60;
			min += div;
			sec -= div * 60;
		}
		if ( min >= 60 ) {
			int div = min / 60;
			hour += div;
			min -= div * 60;
		}
		if ( hour > 0 ) return string.Format( "{0:D2}:{1:D2}:{2:D2}", hour, min, sec );
		else if ( min > 0 ) return string.Format( "{0:D2}:{1:D2}", min, sec );
		return string.Format( "{0}s", sec );
	}

	//시,분,초,  00:00:07 형식으로 빈공간까지 표시.
	public static string MakeTimeTextAll( int hour, int min, int sec )
	{
		if ( sec >= 60 ) {
			int div = sec / 60;
			min += div;
			sec -= div * 60;
		}
		if ( min >= 60 ) {
			int div = min / 60;
			hour += div;
			min -= div * 60;
		}
		return string.Format( "{0:D2}:{1:D2}:{2:D2}", hour, min, sec );
	}

	//00:00:00 시분초 빈공간 제외.
	public static string MakeTimeTextAllWithEmptyClear( int hour, int min, int sec )
	{
		if ( sec >= 60 ) {
			int div = sec / 60;
			min += div;
			sec -= div * 60;
		}
		if ( min >= 60 ) {
			int div = min / 60;
			hour += div;
			min -= div * 60;
		}
		if( hour > 0 ) {
			return string.Format( "{0:D2}:{1:D2}:{2:D2}", hour, min, sec );
		} else {
			if( min > 0 ) {
				return string.Format( "{0:D2}:{1:D2}", min, sec );
			} else {
				if( sec > 0 ) {
					return string.Format( "{0:D2}", sec );
				} else {
					return "0";
				}
			}
		}
	}
}