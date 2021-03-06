using UnityEngine;
using System.Collections.Generic;
using GameDataEditor;

#if GDE_PLAYMAKER_SUPPORT

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(GDMConstants.ActionCategory)]
	[Tooltip(GDMConstants.SetColorActionTooltip)]
	public class GDESetColor : GDESetActionBase
	{   
		[UIHint(UIHint.FsmColor)]
		public FsmColor ColorValue;
		
		public override void Reset()
		{
			base.Reset();
			ColorValue = null;
		}
		
		public override void OnEnter()
		{
            base.OnEnter();
            
			try
			{
				GDEDataManager.SetColor(ItemName.Value, FieldName.Value, ColorValue.Value);
			}
			catch(UnityException ex)
			{
				LogError(string.Format(GDMConstants.ErrorSettingValue, GDMConstants.ColorType, ItemName.Value, FieldName.Value));
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

