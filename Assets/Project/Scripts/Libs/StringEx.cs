using UnityEngine;
using System.Text.RegularExpressions;

public static class StringEx
{
	/// <summary>
	/// 문자열이 null이 아니고 빈 문자열이 아니면 true를 리턴한다.
	/// </summary>
	public static bool IsOk( this string str )
	{
		return !string.IsNullOrEmpty( str );
	}

	public static string GetSafe( this string str )
	{
		return string.IsNullOrEmpty( str ) ? string.Empty : str;
	}

	public static string GetSafe( this string str, string defaultStr )
	{
		return string.IsNullOrEmpty( str ) ? defaultStr : str;
	}

	public static bool IsEmpty( this string str )
	{
		return string.IsNullOrEmpty( str );
	}

	public static bool IsEqual( this string str1, string str2 )
	{
		return string.Equals( str1, str2 );
	}

	public static bool NotEqual( this string str1, string str2 )
	{
		return !string.Equals( str1, str2 );
	}

	public static string ToSafeStr( this object obj )
	{
		return ( obj == null ) ? "NULL" : obj.ToString();
	}

	public static int Sign( this int val )
	{
		return val < 0 ? -1 : val > 0 ? 1 : 0;
	}

	public static float Sign( this float val )
	{
		return val < 0f ? -1f : val > 0f ? 1f : 0f;
	}

	public static string ToLv(this int val)
	{
		return string.Format("Lv.{0}", val);
	}

	public static string ToPlus(this int val )
	{
		return string.Format( "+{0}", val );
	}

	public static string ToMinus( this int val )
	{
		return string.Format( "-{0}", val );
	}

	public static string ToX( this int val )
	{
		return string.Format( "x{0}", val );
	}

	public static string AddSlash(this string path )
	{
		char last = path[path.Length - 1];
		if ( last != '/' ) {
			path += "/";
		}
		return path;
	}
	
	public static string RemoveSlash( this string path )
	{
		char last = path[path.Length - 1];
		if ( last == '/' ) {
			path = path.Remove( path.Length - 1, 1 );
		}
		return path;
	}


	/// <summary>
	/// 진행도 퍼센트 표시시에 이용.
	/// </summary>
	/// <param name="val"></param>
	/// <returns></returns>
	public static string ToPercent(this float val )
	{
		if ( val < 1 ) {
			return string.Format( "{0}%", Mathf.CeilToInt( val * 100f ) );
		} else {
			return "100%";
		}
	}

	//정규식을 이용해서 매개변수 개수 알기.
	public static int GetParamCount(this string val )
	{
		var input = val;
		var pattern = @"{(.*?)}";
		var matches = Regex.Matches( input, pattern );
		var totalMatchCount = matches.Count;                                                            //중복 포함 총 개수
		//var uniqueMatchCount = matches.OfType<Match>().Select( m => m.Value ).Distinct().Count();		//중복제외 개수
		return totalMatchCount;
	}
}