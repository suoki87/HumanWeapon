using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using static System.Convert;
using System.Linq;

#if !UNITY_WEBPLAYER
namespace GameDataEditor
{
public struct RuntimeDataSetInfo
{
	public string ID;
	public DateTime CreateDate;
	public DateTime ModDate;
}

public partial class GDEDataManager
{
	public static HashSet<string> DataSetIDCache = new HashSet<string>();

	/// <summary>
	/// Loads the specified GDE dataset from GDE Online using the GDEOConfig present
	/// in the project
	/// </summary>
	/// <returns><c>true</c>, if the dataset was loaded, <c>false</c> otherwise.</returns>
	public static bool GDEOInit ()
	{
		bool result = false;

		if (!GDEOConfig.ConfigSet())
		{
			Debug.LogError(GDMConstants.ErrorConfigNotSet);
			return false;
		}

		try
		{
			string s3url = GetS3URL(GDEOConfig.GetPDSS3URL());
			GDEODebug.Log(s3url);

			var request = UnityWebRequest.Get(s3url);
			request.SendWebRequest();

			while (!request.isDone) {}

			if (request.responseCode == 200)
			{
				masterData = Json.Deserialize(request.downloadHandler.text) as Dictionary<string, object>;
				BuildDataKeysBySchemaList();
				result = true;
			}
			else
			{
				GDEODebug.Log ("http_resp_code: " + request.responseCode);
				GDEODebug.Log (request.error);
				result = false;
			}
		}
		catch (Exception ex)
		{
			Debug.LogException(ex);
			Debug.Log ("Error fetching primary data set.");
			result = false;
		}

		return result;
	}

	static string GetS3URL(string url)
	{
		string s3url = string.Empty;

		var request = UnityWebRequest.Get(url);
		request.SetRequestHeader("x-api-key", GDEOConfig.APIKey);

		request.SendWebRequest();

		while (!request.isDone) {}

		if (request.responseCode == 200)
		{
			GDEODebug.Log(request.downloadHandler.text);
			var body = Json.Deserialize(request.downloadHandler.text) as Dictionary<string, object>;
			s3url = body["url"].ToString();
		}
		else
			throw new Exception ("Error Response Code: "+request.responseCode+" "+request.error);
		

		return s3url;
	}

	/// <summary>
	/// Uploads the current user data to GDE Online
	/// </summary>
	/// <param name="uid">Unique User ID</param>
	public static bool GDEOSave (string playerID)
	{
		bool result = false;

		if (!GDEOConfig.ConfigSet())
		{
			Debug.LogError(GDMConstants.ErrorConfigNotSet);
			return false;
		}

		try
		{
			using (var stream = new MemoryStream())
			{
				BinaryFormatter bin = new BinaryFormatter ();
				bin.Serialize (stream, ModifiedData);
				var moddataArray = stream.ToArray();
				File.WriteAllBytes(modifiedDataPath, moddataArray);
				
				var fileSize = new FileInfo(modifiedDataPath).Length;

				Debug.Log(modifiedDataPath);
				Debug.Log(fileSize);
				Debug.Log("Max size: "+GDEOConfig.MAX_FILE_SIZE);

				if (fileSize > GDEOConfig.MAX_FILE_SIZE)
					throw new Exception("Runtime File Size too large. It should be less than 3MB");

				string datasetID = GDEOKeyGen.GetUniqueKey(5);
				var url = GDEOConfig.RuntimeDataUrl() + datasetID;

				var formData = new List<IMultipartFormSection>();
				formData.Add(new MultipartFormDataSection("id", datasetID));
				formData.Add(new MultipartFormDataSection("name", playerID));
				formData.Add(new MultipartFormDataSection("username", GDEOConfig.DevID));
				formData.Add(new MultipartFormDataSection("gameid", GDEOConfig.GameID));
				formData.Add(new MultipartFormDataSection("s3Bucket", "gdeonline-datasets"));
				formData.Add(new MultipartFormDataSection("filename", GDEOConfig.FileName));
				formData.Add(new MultipartFormFileSection("rdsBytes", moddataArray, modifiedDataPath, "application/octet-stream"));

				var request = UnityWebRequest.Post(url, formData);
				request.SetRequestHeader("Accept", "application/json, text/plain, */*");
				request.SetRequestHeader("x-api-key", GDEOConfig.APIKey);

				request.SendWebRequest();
				while (!request.isDone) {}

				GDEODebug.Log(request.responseCode);

				if (request.responseCode == 200)
				{
					DataSetIDCache.Add(datasetID);
					result = true;
				}
				else
				{
					Debug.LogError(request.error);
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogError (GDMConstants.ErrorSavingData);
			Debug.LogException (ex);

			result = false;
		}

		return result;
	}

	public static List<RuntimeDataSetInfo> GDEOGetRuntimeDataIDs (string uid)
	{
		List<RuntimeDataSetInfo> datasetInfos = null;

		if (!GDEOConfig.ConfigSet())
		{
			Debug.LogError(GDMConstants.ErrorConfigNotSet);
			return null;
		}

		try
		{
			string url = GDEOConfig.RuntimeDataListUrl(uid);
			var request = UnityWebRequest.Get(url);
			request.SetRequestHeader("x-api-key", GDEOConfig.APIKey);

			request.SendWebRequest();
			while (!request.isDone) {}

			GDEODebug.Log(url);
			GDEODebug.Log(request.responseCode.ToString());

			if (request.responseCode == 200)
			{
				GDEODebug.Log(request.downloadHandler.text);

				datasetInfos = new List<RuntimeDataSetInfo>();
				var responseDict = Json.Deserialize(request.downloadHandler.text) as List<object>;
				foreach (var item in responseDict)
				{
					var infoItem = item as Dictionary<string, object>;
					var temp = new RuntimeDataSetInfo();
					temp.ID = infoItem["id"].ToString();
					temp.CreateDate = DateTime.Parse(infoItem["createDate"].ToString());
					temp.ModDate = DateTime.Parse(infoItem["modDate"].ToString());
					datasetInfos.Add(temp);
				}
			}
			else
			{
				GDEODebug.Log ("http_resp_code: " + request.responseCode);
				GDEODebug.Log (request.error);
			}
		}
		catch (Exception ex)
		{
			Debug.LogException(ex);
		}

		return datasetInfos;
	}

	public static bool GDEOGetRuntimeData(string rdsID)
	{
		bool result = false;

		if (!GDEOConfig.ConfigSet())
		{
			Debug.LogError(GDMConstants.ErrorConfigNotSet);
			return false;
		}

		try
		{
			string url = GDEOConfig.GetRDSS3URL(rdsID);
			GDEODebug.Log(url);

			string s3url = GetS3URL(url);
			GDEODebug.Log(s3url);

			var request = UnityWebRequest.Get(s3url);
			request.SendWebRequest();

			while (!request.isDone) {}

			if (request.responseCode == 200)
			{
				GDEODebug.Log(request.downloadHandler.data);				
				using (var stream = new MemoryStream(request.downloadHandler.data))
				{
					BinaryFormatter bin = new BinaryFormatter();
					ModifiedData = bin.Deserialize(stream) as Dictionary<string, Dictionary<string, object>>;
					File.WriteAllBytes(modifiedDataPath, stream.ToArray());
				}

				result = true;
			}
		}
		catch (Exception ex)
		{
			Debug.LogException(ex);
			result = false;
		}

		return result;
	}

	public static bool GDEODeleteRuntimeData (string playerID, string rdsID)
	{
		if (!GDEOConfig.ConfigSet())
		{
			Debug.LogError(GDMConstants.ErrorConfigNotSet);
			return false;
		}

		string url = GDEOConfig.RuntimeDataSetDeleteUrl(playerID, rdsID);
		url += "?filename="+UnityWebRequest.EscapeURL(GDEOConfig.RDSFileName)+"&s3Bucket=gdeonline-datasets";
		var request = UnityWebRequest.Delete(url);

		GDEODebug.Log(url);

		try
		{
			request.SetRequestHeader("x-api-key", GDEOConfig.APIKey);

			ClearSaved();
			request.SendWebRequest();

			while (!request.isDone) {}
		}
		catch (Exception ex)
		{
			Debug.LogException(ex);
		}

		GDEODebug.Log(request.responseCode);
		return request.responseCode == 200;
	}
}
}
#else
namespace GameDataEditor
{
public partial class GDEDataManager
{
	public static bool GDEOInit (string ID)
	{
		throw new Exception("GDE Online is not supported in Web Player!");
	}
}
}
#endif
