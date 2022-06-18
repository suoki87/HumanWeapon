using UnityEngine;
using System.Collections.Generic;

public static class Rands
{
	/// 랜덤 시드 변경 세팅
	public static void SetSeed( int seed )
	{
		UnityEngine.Random.InitState( seed );
	}

	public static float GetValue()
	{
		return UnityEngine.Random.value;
	}

	/// <summary>
	/// 1~100 사이의 랜덤값을 뽑아 trueWeight의 확률로 true를 리턴한다.
	/// </summary>
	/// <param name="trueWeight">1~100 사이의 정수.</param>
	public static bool Percent( int trueWeight )
	{
		return Range( 1, 100 ) <= trueWeight;
	}

	/// <summary>
	/// 1.0~100.0 사이의 랜덤값을 뽑아 trueWeight의 확률로 true를 리턴한다.
	/// </summary>
	/// <param name="trueWeight">1~100 사이의 실수.</param>
	public static bool PercentF( float trueWeight )
	{
		return Range( 0f, 100f ) < trueWeight;
	}

	/// <summary>
	/// SortedList의 key를 weight로 하여 랜덤하게 value를 리턴한다.
	/// </summary>
	public static T Weighted<T>( SortedList<int, T> list )
	{
		int max = list.Keys[list.Keys.Count-1];
		int random = Range( 0, max );

		foreach( int key in list.Keys )
		{
			if( random <= key )
				return list[key];
		}
		return default(T);
	}

	/// 가중치 뽑기
	public static T WeightedRandomItem<T>( IList<T> list, IEnumerable<int> weights )
	{
		return list[WeightedRandomIdx(weights)];
	}

	/// 가중치 뽑기
	public static int WeightedRandomIdx( IEnumerable<int> weights )
	{
		int totalWeight = 0;
		foreach( var w in weights ) { totalWeight += w; }

		int random_num = Range( 1, totalWeight );
		int weight_sum = 0;
		int idx = 0;

		foreach( var w in weights ) {
			weight_sum += w;
			if( random_num <= weight_sum )
				return idx;
			idx++;
		}
		return -1;
	}

	/// 배열에서 랜던한 요소를 하나 반환
	public static T PickOne<T>( T[] array )
	{
		return array[ RangeEx( 0, array.Length ) ];
	}

	/// float 형 Range
	public static float Range( float min, float max )
	{
		return UnityEngine.Random.Range(min, max);
	}

	public static float Range( Vector2 range )
	{
		return UnityEngine.Random.Range(range.x, range.y);
	}

	/// <summary>
	/// int 형 Range max를 포함 하도록
	/// </summary>
	public static int Range( int min, int max )
	{
		if (min == max) return min;
		return UnityEngine.Random.Range(min, max + 1);
	}

	/// <summary>
	/// int 형 Range max 제외
	/// </summary>
	public static int RangeEx( int min, int max )
	{
		return UnityEngine.Random.Range(min, max);
	}

	/// <summary>
	/// max값을 포함(inclusive)한 범위 값을 리턴한다.
	/// lastVal에 값을 저장하여 같은 값은 리턴하지 않는다.
	/// </summary>
	public static int UniqueRange( int min, int max, ref int lastVal )
	{
		int res;
		do { res = Range( min, max ); } while( res == lastVal );
		lastVal = res;
		return res;
	}

	/// <summary>
	/// max값을 불포함(exclusive)한 범위 값을 리턴한다.
	/// lastVal에 값을 저장하여 같은 값은 리턴하지 않는다.
	/// </summary>
	public static int UniqueRangeEx( int min, int max, ref int lastVal )
	{
		int res;
		do { res = RangeEx( min, max ); } while( res == lastVal );
		lastVal = res;
		return res;
	}

	/// Dir 이 -1/1 인경우 랜덤한 Dir 
	public static int GetRandDirX()
	{
		return GetRandBool() ? 1 : -1;
	}

	/// 둘 중 하나의 랜덤 분기 일때 
	public static bool GetRandBool()
	{
		return Rands.Range( 0, 2 ) == 0;
	}
}