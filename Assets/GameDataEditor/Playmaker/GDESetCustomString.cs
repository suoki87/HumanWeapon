using UnityEngine;
using System.Collections.Generic;
using GameDataEditor;

#if GDE_PLAYMAKER_SUPPORT

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(GDMConstants.ActionCategory)]
	[Tooltip(GDMConstants.SetCustomStringActionTooltip)]
	public class GDESetCustomString : GDESetActionBase
	{   
		[UIHint(UIHint.FsmString)]
		[Tooltip(GDMConstants.StringCustomFieldTooltip)]
		public FsmString CustomField;
		
		[UIHint(UIHint.FsmString)]
		public FsmString StringValue;
		
		public override void Reset()
		{
			base.Reset();
			StringValue = null;
		}
		
		public override void OnEnter()
		{
            base.OnEnter();
            
			try
			{	
				Dictionary<string, object> data;
				string customKey;

				if (GDEDataManager.DataDictionary.ContainsKey(ItemName.Value))
				{
					GDEDataManager.Get(ItemName.Value, out data);
					data.TryGetString(FieldName.Value, out customKey);
					customKey = GDEDataManager.GetString(ItemName.Value, FieldName.Value, customKey);
				}
				else
				{
					// New Item Case
					customKey = GDEDataManager.GetString(ItemName.Value, FieldName.Value, string.Empty);
				}

				GDEDataManager.SetString(customKey, CustomField.Value, StringValue.Value);
			}
			catch(UnityException ex)
			{
				LogError(string.Format(GDMConstants.ErrorSettingCustomValue, GDMConstants.StringType, ItemName.Value, FieldName.Value, CustomField.Value));
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

