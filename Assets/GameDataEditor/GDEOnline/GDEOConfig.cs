using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GameDataEditor
{
public class GDEOConfig
{
	/*****************************************************/
	/***** Fill in the following section
	/***** from the values in the
	/***** GDEO Developer Portal in your account.
	/*****************************************************/
	public const string APIKey = "";
	public const string DevID = "";
	public const string GameID = "";
	public const string GameName = "";
	public const string FileName = ""; // Do NOT include extension!
	/*****************************************************/
	/***** Do not edit anything beyond this line *********/
	/*****************************************************/

	const string BASE_URL = "https://rasa43qtgk.execute-api.us-east-1.amazonaws.com/beta/gcapi/";
	const string GAMES_ENDPOINT = "games/";
	const string RUNTIME_DS_ENDPOINT = "runtimedatasets/";
	const string S3_PDS_URL_ENDPOINT = "s3urls/pds/";
	const string S3_RDS_URL_ENDPOINT = "s3urls/rds/";
	public const string RDSFileName = "gde_mod_data";
	public const double MAX_FILE_SIZE = 1024 * 1024 * 3;


	public static bool ConfigSet()
	{
		return !APIKey.Equals(string.Empty) && !DevID.Equals(string.Empty) &&
		       !GameID.Equals(string.Empty) && !GameName.Equals(string.Empty) &&
		       !FileName.Equals(string.Empty);
	}

	public static string PrimaryDataUrl()
	{
		return BASE_URL + GAMES_ENDPOINT + DevID + "/" + GameID;
	}

	public static string RuntimeDataUrl()
	{
		return BASE_URL + RUNTIME_DS_ENDPOINT;
	}

	public static string RuntimeDataListUrl(string playerID)
	{
		return BASE_URL + RUNTIME_DS_ENDPOINT + "/playerid/" + DevID + "/" + GameID + "/" + playerID;
	}

	public static string RuntimeDataSetDeleteUrl(string playerID, string rdsID)
	{
		return BASE_URL + RUNTIME_DS_ENDPOINT + DevID + "/" + GameID + "/" + playerID + "/" + rdsID;
	}

	public static string GetPDSS3URL()
	{
		return BASE_URL + S3_PDS_URL_ENDPOINT + "get/" + DevID + "/" + GameID + "/" + FileName;
	}

	public static string GetRDSS3URL(string rdsID)
	{
		return BASE_URL + S3_RDS_URL_ENDPOINT + "get/" + DevID + "/" + GameID + "/" + rdsID + "/" + RDSFileName;
	}
}
}
