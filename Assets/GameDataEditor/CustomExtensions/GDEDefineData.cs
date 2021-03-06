// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by the Game Data Editor.
//
//      Changes to this file will be lost if the code is regenerated.
//
//      This file was generated from this data file:
//      C:/Project/HumanWeapon/Assets/GameDataEditor/Resources/gde_data.txt
//  </autogenerated>
// ------------------------------------------------------------------------------
using UnityEngine;
using UnityEngine.Video;
using System;
using System.Linq;
using System.Collections.Generic;

using GameDataEditor;

namespace GameDataEditor
{
    public class GDEDefineData : IGDEData
    {
        static string valueKey = "value";
		float _value;
        public float value
        {
            get { return _value; }
            set {
                if (_value != value)
                {
                    _value = value;
					GDEDataManager.SetFloat(_key, valueKey, _value);
                }
            }
        }

        public GDEDefineData(string key) : base(key)
        {
            GDEDataManager.RegisterItem(this.SchemaName(), key);
        }
        public override Dictionary<string, object> SaveToDict()
		{
			var dict = new Dictionary<string, object>();
			dict.Add(GDMConstants.SchemaKey, "Define");
			
            dict.Merge(true, value.ToGDEDict(valueKey));
            return dict;
		}

        public override void UpdateCustomItems(bool rebuildKeyList)
        {
        }

        public override void LoadFromDict(string dataKey, Dictionary<string, object> dict)
        {
            _key = dataKey;

			if (dict == null)
				LoadFromSavedData(dataKey);
			else
			{
                dict.TryGetFloat(valueKey, out _value);
                LoadFromSavedData(dataKey);
			}
		}

        public override void LoadFromSavedData(string dataKey)
		{
			_key = dataKey;
			
            _value = GDEDataManager.GetFloat(_key, valueKey, _value);
        }

        public GDEDefineData ShallowClone()
		{
			string newKey = Guid.NewGuid().ToString();
			GDEDefineData newClone = new GDEDefineData(newKey);

            newClone.value = value;

            return newClone;
		}

        public GDEDefineData DeepClone()
		{
			GDEDefineData newClone = ShallowClone();
            return newClone;
		}

        public void Reset_value()
        {
            GDEDataManager.ResetToDefault(_key, valueKey);

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            dict.TryGetFloat(valueKey, out _value);
        }

        public void ResetAll()
        {
             #if !UNITY_WEBPLAYER
             GDEDataManager.DeregisterItem(this.SchemaName(), _key);
             #else

            GDEDataManager.ResetToDefault(_key, valueKey);


            #endif

            Dictionary<string, object> dict;
            GDEDataManager.Get(_key, out dict);
            LoadFromDict(_key, dict);
        }
    }
}
