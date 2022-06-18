using UnityEngine;
using UnityEngine.Video;
using System;
using System.Collections.Generic;
using GameDataEditor;


#if GDE_PLAYMAKER_SUPPORT 

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(GDMConstants.ActionCategory)]
	[Tooltip(GDMConstants.GetVideoClipListActionTooltip)]
	public class GDEGetVideoClipArray : GDEActionBase
	{
		[UIHint(UIHint.Variable)]
		public FsmArray StoreResult;
		
		public override void Reset()
		{
			base.Reset();
			
			if (StoreResult != null)
				StoreResult.Reset();
		}
		
		public override void OnEnter()
		{
			try
			{
				Dictionary<string, object> data;
				List<VideoClip> val = null;
				if (GDEDataManager.Get(ItemName.Value, out data))
					data.TryGetVideoClipList(FieldName.Value, out val);
				
				// Override from saved data if it exists
				val = GDEDataManager.GetUnityObjectList<VideoClip>(ItemName.Value, FieldName.Value, val);
				StoreResult.SetArrayContents(val);
			}
			catch(UnityException ex)
			{
				LogError(ex.ToString());
			}
			finally
			{
				Finish();       
			}
		}
	}
}

#endif